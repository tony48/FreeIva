﻿using System;
using UnityEngine;

namespace FreeIva
{
    public static class Settings
    {
        public static KeyCode UnbuckleKey = KeyCode.Y; // Get out of/into seat.
        public static KeyCode OpenHatchKey = KeyCode.F; // Open or close a hatch.
        // ModifierKey + OpenHatchKey toggles the hatch of the part adjoining the one you're currently in when used with basic Hatches.
        // This won't be needed with mesh hatches with interaction colliders.
        // ModifierKey + UnbuckleKey locks camera movement to click on menus etc.
        public static KeyCode ModifierKey = KeyCode.LeftAlt;

        public static KeyCode ForwardKey = KeyCode.W;
        public static KeyCode BackwardKey = KeyCode.S;
        public static KeyCode LeftKey = KeyCode.A;
        public static KeyCode RightKey = KeyCode.D;
        public static KeyCode RollCCWKey = KeyCode.Q;
        public static KeyCode RollCWKey = KeyCode.E;
        public static KeyCode UpKey = KeyCode.LeftShift;
        public static KeyCode DownKey = KeyCode.LeftControl;
        public static KeyCode JumpKey = KeyCode.Space;

        public static float ForwardSpeed = 1f;
        public static float HorizontalSpeed = 1f;
        public static float VerticalSpeed = 1f;
        // TODO: Free look
        public static float YawSpeed = 7f;
        public static float PitchSpeed = 7f;
        public static float RollSpeed = 100f;
        // TODO: Gravity look
        public static float YawSensitivity = 0.5f;
        public static float PitchSensitivity = 0.5f;

        public static float JumpForce = 10f;

        public static float KerbalHeight = 2f;
        public static float KerbalHeightWithHelmet = 2.5f;

        // The size of a kerbal's head collider when they're wearing their helmet.
        public static float HelmetSize = 0.6f;
        // Taking off the helmet may allow squeezing through tight spaces, with some risk (when pressurisation and injury are implemented).
        public static float NoHelmetSize = 0.4f;

        // The radius of the sphere which, when looked at, will trigger interaction prompts.
        // TODO: Replace this with interaction colliders.
        public static float ObjectInteractionRadius = 0.3f;
        // The maximum range from an object at which interaction prompts will appear.
        public static float MaxInteractDistance = 1f;

        public static void LoadSettings()
        {
            Debug.Log("[FreeIVA] Loading settings...");
            ConfigNode settings = GameDatabase.Instance.GetConfigNode("FreeIva/settings/FreeIvaConfig");
            if (settings == null)
            {
                Debug.LogWarning("[FreeIVA] FreeIva/settings.cfg not found! Using default values.");
                return;
            }

            // Keys
            if (settings.HasValue("UnbuckleKey")) UnbuckleKey = (KeyCode)Enum.Parse(typeof(KeyCode), settings.GetValue("UnbuckleKey"));
            if (settings.HasValue("OpenHatchKey")) OpenHatchKey = (KeyCode)Enum.Parse(typeof(KeyCode), settings.GetValue("OpenHatchKey"));
            if (settings.HasValue("ModifierKey")) ModifierKey = (KeyCode)Enum.Parse(typeof(KeyCode), settings.GetValue("ModifierKey"));
            if (settings.HasValue("ForwardKey")) ForwardKey = (KeyCode)Enum.Parse(typeof(KeyCode), settings.GetValue("ForwardKey"));
            if (settings.HasValue("BackwardKey")) BackwardKey = (KeyCode)Enum.Parse(typeof(KeyCode), settings.GetValue("BackwardKey"));
            if (settings.HasValue("LeftKey")) LeftKey = (KeyCode)Enum.Parse(typeof(KeyCode), settings.GetValue("LeftKey"));
            if (settings.HasValue("RightKey")) RightKey = (KeyCode)Enum.Parse(typeof(KeyCode), settings.GetValue("RightKey"));
            if (settings.HasValue("RollCCWKey")) RollCCWKey = (KeyCode)Enum.Parse(typeof(KeyCode), settings.GetValue("RollCCWKey"));
            if (settings.HasValue("RollCWKey")) RollCWKey = (KeyCode)Enum.Parse(typeof(KeyCode), settings.GetValue("RollCWKey"));
            if (settings.HasValue("UpKey")) UpKey = (KeyCode)Enum.Parse(typeof(KeyCode), settings.GetValue("UpKey"));
            if (settings.HasValue("DownKey")) DownKey = (KeyCode)Enum.Parse(typeof(KeyCode), settings.GetValue("DownKey"));

            // Axis multipliers
            if (settings.HasValue("ForwardSpeed")) ForwardSpeed = float.Parse(settings.GetValue("ForwardSpeed"));
            if (settings.HasValue("HorizontalSpeed")) HorizontalSpeed = float.Parse(settings.GetValue("HorizontalSpeed"));
            if (settings.HasValue("VerticalSpeed")) VerticalSpeed = float.Parse(settings.GetValue("VerticalSpeed"));
            if (settings.HasValue("YawSpeed")) YawSpeed = float.Parse(settings.GetValue("YawSpeed"));
            if (settings.HasValue("PitchSpeed")) PitchSpeed = float.Parse(settings.GetValue("PitchSpeed"));
            if (settings.HasValue("RollSpeed")) RollSpeed = float.Parse(settings.GetValue("RollSpeed"));
            if (settings.HasValue("YawSensitivity")) YawSpeed = float.Parse(settings.GetValue("YawSensitivity"));
            if (settings.HasValue("PitchSensitivity")) PitchSpeed = float.Parse(settings.GetValue("PitchSensitivity"));

            // Misc.
            if (settings.HasValue("HeadSize")) HelmetSize = float.Parse(settings.GetValue("HeadSize"));
            if (settings.HasValue("NoHelmetSize")) NoHelmetSize = float.Parse(settings.GetValue("NoHelmetSize"));
        }
    }
}
