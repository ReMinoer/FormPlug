using System;

namespace FormPlug
{
    internal class SocketPlugger<TValue, TControl> : IPlugger
    {
        private readonly IPlug<TValue, TControl> _plug;
        private readonly Socket<TValue> _socket;

        public SocketPlugger(IPlug<TValue, TControl> plug, Socket<TValue> socket)
        {
            _plug = plug;
            _socket = socket;

            _plug.Value = _socket;

            _plug.ValueChanged += OnPlugValueChanged;
            _socket.ValueChanged += OnSocketValueChanged;
        }

        private void OnPlugValueChanged(object sender, EventArgs eventArgs)
        {
            _socket.Value = _plug.Value;
        }

        private void OnSocketValueChanged(object sender, EventArgs eventArgs)
        {
            _plug.Value = _socket.Value;
        }
    }
}