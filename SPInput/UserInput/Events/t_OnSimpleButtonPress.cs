﻿using UnityEngine;

using com.spacepuppy.Events;

namespace com.spacepuppy.UserInput.Events
{

    public sealed class t_OnSimpleButtonPress : TriggerComponent
    {

        #region Fields

        [SerializeField]
        [Tooltip("Leave blank to use main input device.")]
        private string _deviceId;

        [SerializeField]
        [DisableOnPlay]
        private string _inputId;
        
        #endregion

        #region CONSTRUCTOR
            
        #endregion

        #region Properties

        public string InputId
        {
            get
            {
                return _inputId;
            }
            set
            {
                _inputId = value;
            }
        }

        #endregion

        #region Methods

        private void Update()
        {
            var service = Services.Get<IGameInputManager>();
            if(service != null)
            {
                var input = string.IsNullOrEmpty(_deviceId) ? service.Main : service.GetDevice(_deviceId);
                if (input == null) return;

                if (input.GetCurrentButtonState(_inputId) == UserInput.ButtonState.Down)
                {
                    this.ActivateTrigger(null);
                }
            }
            else
            {
                if (Input.GetButtonDown(_inputId))
                {
                    this.ActivateTrigger(null);
                }
            }
        }

        #endregion

    }

}