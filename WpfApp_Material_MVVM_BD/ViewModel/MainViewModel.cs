using DAL.Context;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Ninject;
using Repository;
using WpfApp_Material_MVVM_BD.Moduls;
using WpfApp_Material_MVVM_BD.Infrastracture;

namespace WpfApp_Material_MVVM_BD.ViewModel
{
    class MainViewModel: INotifyPropertyChanged
    {
        private ObservableCollection<Good> _goods;
        private ObservableCollection<Manufacture> _manufactures;
        private ObservableCollection<Category> _categories;
        #region Properties
        public ObservableCollection<Category> Categories
        {
            get { return _categories; }
            set { _categories = value; Notify(); }
        }
        public Category SelectedCategory { get; set; }
        public ObservableCollection<Manufacture> Manufactures
        {
            get { return _manufactures; }
            set { _manufactures = value; Notify(); }
        }
        public Manufacture SelectedManufacture { get; set; }
        public ObservableCollection<Good> Goods
        {
            get { return _goods; }
            set { _goods = value;  Notify(); }
        }
        public Good SelectedGood { get; set; }
        #endregion
        #region Commands
        public ICommand WindowsClosed { get; set; }
        #endregion
        public MainViewModel()
        {
            IKernel kernel = new StandardKernel(new MyModule());
            IRepository < Good > goods = kernel.Get<IRepository<Good>>();
            IRepository < Category > categories= kernel.Get<IRepository<Category>>();
            IRepository < Manufacture > manufactures= kernel.Get<IRepository<Manufacture>>();
            _goods = new ObservableCollection<Good>(goods.GetAll());
            _categories = new ObservableCollection<Category>(categories.GetAll());
            _manufactures = new ObservableCollection<Manufacture>(manufactures.GetAll());
            WindowsClosed = new RelayCommand(x => {

                goods.Save();
                categories.Save();
                manufactures.Save();

            });

        }
        #region Notify
        void Notify([CallerMemberName] string propertyName ="")
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
