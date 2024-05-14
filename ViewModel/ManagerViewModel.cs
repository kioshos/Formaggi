using Formaggi.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Formaggi.ViewModel
{
    public class ManagerViewModel : ViewModelBase
    {
        private Page _currentContentVM;

        public Page CurrentContentVM
        {
            get => _currentContentVM;
            set
            {
                if (_currentContentVM != value)
                {
                    _currentContentVM = value;
                    OnPropertyChanged(nameof(CurrentContentVM));
                }
            }
        }
        public ICommand CurrentContentCommand { get; private set; }
        public ICommand IngredientContentCommand { get; private set; }
        public ICommand CheeseContentCommand { get; private set; }

        public ManagerViewModel()
        {
            CurrentContentCommand = new RelayCommand(CurrentContext,null);
            IngredientContentCommand = new RelayCommand(IngredientContext, null);
            CheeseContentCommand = new RelayCommand(CheeseContext,null);
        }

        private void CheeseContext() => CurrentContentVM = new CheesePage();

        private void IngredientContext() => CurrentContentVM = new IngredientPage();
        private void CurrentContext() => CurrentContentVM = new StaffPage();

    }
}
