using Formaggi.Model;
using Formaggi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formaggi.ViewModel
{
    public class IngredientViewModel : ViewModelBase
    {
        private IngredientContext _ingredientContext;
        private List<Ingredient> _ingredientsList;

        public List<Ingredient> IngredientsList { get => _ingredientsList; set => _ingredientsList = value; }
        public IngredientViewModel()
        {
            _ingredientContext = new IngredientContext();

        }
    }
}
