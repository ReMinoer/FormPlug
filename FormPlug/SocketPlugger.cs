using System;

namespace FormPlug
{
    public class SocketPlugger<T> : IPlugger
    {
        private readonly IPlug<T> _plug;
        private readonly Socket<T> _socket;

        public SocketPlugger(IPlug<T> plug, Socket<T> socket)
        {
            _plug = plug;
            _socket = socket;

            _plug.PluggedValue = _socket;
            _plug.PlugValueChanged += OnPlugValueChanged;

            _socket.ValueChanged += OnSocketValueChanged;
        }

        private void OnPlugValueChanged(object sender, EventArgs eventArgs)
        {
            _socket.Value = _plug.PluggedValue;
        }

        private void OnSocketValueChanged(object sender, EventArgs eventArgs)
        {
            _plug.PluggedValue = _socket;
        }
    }
}