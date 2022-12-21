﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FreeIva
{
	internal class Kerbalism_GravityRing : ICentrifuge, IDeployable
	{
		#region static

		static TypeInfo x_GravityRingTypeInfo;
		static FieldInfo x_rotate_transfFieldInfo;
		static FieldInfo x_deployedFieldInfo;
		static FieldInfo x_deploy_animFieldInfo;

		static Kerbalism_GravityRing()
		{
			var type = AssemblyLoader.GetClassByName(typeof(PartModule), "GravityRing");

			if (type == null) return;

			x_GravityRingTypeInfo = type.GetTypeInfo();
			x_rotate_transfFieldInfo = x_GravityRingTypeInfo.GetField("rotate_transf", BindingFlags.Instance | BindingFlags.Public);
			x_deployedFieldInfo = x_GravityRingTypeInfo.GetField("deployed", BindingFlags.Instance | BindingFlags.Public);
			x_deploy_animFieldInfo = x_GravityRingTypeInfo.GetField("deploy_anim", BindingFlags.Instance | BindingFlags.Public);
		}

		public static Kerbalism_GravityRing Create(Part part)
		{
			if (x_GravityRingTypeInfo == null) return null;

			PartModule module = null;
			foreach (var m in part.modules.modules)
			{
				if (m.GetType() == x_GravityRingTypeInfo.AsType())
				{
					module = m;
					break;
				}
			}

			if (module == null) return null;

			return new Kerbalism_GravityRing(module);
		}

		#endregion

		PartModule m_module;
		Kerbalism_Transformator m_transformator;
		Kerbalism_Animator m_deploy_anim;

		static Quaternion postRotation = Quaternion.Euler(180, 0, 180);

		public Kerbalism_GravityRing(PartModule module)
		{
			m_module = module;
			object transformator = x_rotate_transfFieldInfo.GetValue(m_module);
			if (transformator != null)
			{
				m_transformator = new Kerbalism_Transformator(transformator);
				m_transformator.rotate_iva = false;
			}

			object animator = x_deploy_animFieldInfo.GetValue(m_module);
			if (animator != null) m_deploy_anim = new Kerbalism_Animator(animator);
		}

		public void Update()
		{
			if (m_transformator != null)
			{
				m_module.part.internalModel.transform.rotation = InternalSpace.WorldToInternal(m_transformator.transform.rotation) * postRotation;
			}
		}

		public float CurrentSpinRate
		{
			get { return m_transformator.CurrentSpinRate; }
		}

		public Transform IVARotationRoot => m_module.part.internalModel.transform;

		public bool IsDeployed
		{
			get
			{
				bool deployed = (bool)x_deployedFieldInfo.GetValue(m_module);

				return deployed && !m_deploy_anim.Playing();
			}
		}
	}
}
