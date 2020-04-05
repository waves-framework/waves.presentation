using Fluid.Core.Devices.Interfaces.Input.ADC;
using Fluid.Presentation.Base;

namespace Fluid.Presentation.Devices.ViewModel
{
    /// <summary>
    /// Analog-digital converter presentation view model.
    /// </summary>
    public class AdcPresentationViewModel : PresentationViewModel
    {
        private IAdc _adc;
        private bool _isUsing;

        /// <summary>
        /// Creates new instance of ADC presentation view model.
        /// </summary>
        /// <param name="device">Device.</param>
        public AdcPresentationViewModel(IAdc device)
        {
            Adc = device;
        }

        /// <summary>
        /// Gets or sets whether ADC is using.
        /// </summary>
        public bool IsUsing
        {
            get => _isUsing;
            private set
            {
                if (value == _isUsing) return;
                _isUsing = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets ADC device instance.
        /// </summary>
        public IAdc Adc
        {
            get => _adc;
            private set
            {
                if (Equals(value, _adc)) return;
                _adc = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc />
        public override void Initialize()
        {
        }
    }
}