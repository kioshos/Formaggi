using Formaggi.Model;
using Formaggi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formaggi.ViewModel
{
    class BatchWindowViewModel : ViewModelBase
    {
        private StorageContext _storageContext;
        private List<Batch> _batchList;

        public List<Batch> Batches
        {
            get { return _batchList; }
            set { _batchList = value; }
        }

        public BatchWindowViewModel(int cheeseID)
        {
            _storageContext = new StorageContext();
            _batchList = _storageContext.GetCheeseBatchById(cheeseID);
        }
    }
}
