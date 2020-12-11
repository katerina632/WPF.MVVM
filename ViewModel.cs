using MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM
{
    public class ViewModel : INotifyPropertyChanged
    {
        private readonly ICollection<ColorModel> colors = new ObservableCollection<ColorModel>();
        public IEnumerable<ColorModel> Colors => colors;

        private Command addColorCommand;
        private Command deleteColorCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        private ColorModel selectedColor;
        public ColorModel SelectedColor
        {
            get { return selectedColor; }
            set
            {
                if (value != selectedColor)
                {
                    selectedColor = value;
                    OnPropertyChanged();
                }

            }
        }
        public ViewModel()
        {
            SelectedColor = new ColorModel();

            addColorCommand = new DelegateCommand(AddColor, IsTheSame);
            deleteColorCommand = new DelegateCommand(RemoveSelectedColor, () => SelectedColor != null);

            PropertyChanged += (sender, args) =>
            {
                
                if (args.PropertyName == nameof(SelectedColor))
                {
                    addColorCommand.RaiseCanExecuteChanged();
                    deleteColorCommand.RaiseCanExecuteChanged();
                }
            };
        }

        public bool IsTheSame()
        {
            return !colors.Contains(SelectedColor);
        }

        public ICommand AddColorCommand => addColorCommand;
        public ICommand DeleteColorCommand => deleteColorCommand;

        public void AddColor()
        {
            if (SelectedColor != null)
            {
                colors.Add((ColorModel)SelectedColor.Clone());
            }
        }


        public void RemoveSelectedColor()
        {
            if (SelectedColor != null)
            {
                colors.Remove(SelectedColor);
                SelectedColor = new ColorModel();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
