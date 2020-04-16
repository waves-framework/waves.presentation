using Fluid.Core.Devices.Interfaces.Input.ADC;
using Fluid.Presentation.Base;

namespace Fluid.Presentation.Devices.ViewModel
{
    /// <summary>
    ///     View model for ADC entry point.
    /// </summary>
    public class AdcEntryPointViewModel : PresentationViewModel
    {
        private IAdcEntryPoint _entryPoint;
        private bool _isUsing;

        /// <summary>
        ///     Creates new instance of Adc Entry point.
        /// </summary>
        /// <param name="entryPoint"></param>
        public AdcEntryPointViewModel(IAdcEntryPoint entryPoint)
        {
            EntryPoint = entryPoint;
        }

        /// <summary>
        ///     Gets or sets whether entry point (channel) is using.
        /// </summary>
        public bool IsUsing
        {
            get => _isUsing;
            set
            {
                if (value == _isUsing) return;
                _isUsing = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets instance of Entry point.
        /// </summary>
        public IAdcEntryPoint EntryPoint
        {
            get => _entryPoint;
            private set
            {
                if (Equals(value, _entryPoint)) return;
                _entryPoint = value;
                OnPropertyChanged();
            }
        }

        /// <inheritdoc />
        public override void Initialize()
        {
        }
    }
}