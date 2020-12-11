using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MVVM
{
    public class ColorModel : INotifyPropertyChanged
    {
        private byte alpha;
        public byte Alpha
        {
            get { return alpha; }
            set
            {
                if (alpha != value)
                {
                    alpha = value;
                    Color = Color.FromArgb(alpha, red, green, blue);
                    OnPropertyChanged(nameof(Color));
                    OnPropertyChanged();
                }
            }
        }

        private byte red;
        public byte Red
        {
            get { return red; }
            set
            {
                if (red != value)
                {
                    red = value;
                    Color = Color.FromArgb(alpha, red, green, blue);
                    OnPropertyChanged(nameof(Color));
                    OnPropertyChanged();
                }
            }
        }

        private byte green;
        public byte Green
        {
            get { return green; }
            set
            {
                if (green != value)
                {
                    green = value;
                    Color = Color.FromArgb(alpha, red, green, blue);
                    OnPropertyChanged(nameof(Color));
                    OnPropertyChanged();
                }
            }
        }

        private byte blue;
        public byte Blue
        {
            get { return blue; }
            set
            {
                if (blue != value)
                {
                    blue = value;
                    Color = Color.FromArgb(alpha, red, green, blue);
                    OnPropertyChanged(nameof(Color));
                    OnPropertyChanged();
                }
            }
        }

        private Color _color;
        public Color Color
        {
            get { return _color; }
            set
            {
                if (_color != value)
                {
                    _color = value;
                    Color = Color.FromArgb(alpha, red, green, blue);
                    OnPropertyChanged(nameof(Color));
                    OnPropertyChanged();
                }
            }
        }

        public ColorModel()
        {
            Alpha = 0;
            Red = 0;
            Green = 0;
            Blue = 0;
            Color = Colors.White;
        }

        public object Clone()
        {
            return (ColorModel)this.MemberwiseClone();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
