using System;

namespace Utils
{
    public class ObservableProperty<T> where T : struct
    {
        private T _value;

        public event Action<T> OnChanged;

        public T Value
        {
            get => _value;
            set
            {
                if (_value.Equals(value))
                    return;

                _value = value;
                OnChanged?.Invoke(_value);
            }
        }
    }
}