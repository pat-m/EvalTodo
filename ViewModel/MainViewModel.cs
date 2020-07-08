using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EvalTodo.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Task> Tasks { get; set; }
        private int _TasksDone;
        public int TasksDone {
            get
            {
                return this._TasksDone;
            }
            set
            {
                this._TasksDone = value;
                RaisePropertyChanged();
            }
        }
        private Task _SelectedTask;
        public Task SelectedTask {
            get
            {
                return this._SelectedTask;
            }
            set
            {
                this._SelectedTask = value;
                RaisePropertyChanged();
            }
        }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteAllCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public Task NewTask {get; set;}
        private String _Name {get; set;}
        public String Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                this._Name = value;
                RaisePropertyChanged();
            }
        }
        private DateTime _SelectedDate;
        public DateTime SelectedDate {
            get { 
                return this._SelectedDate; 
            }
            set {
                this._SelectedDate = value;
                RaisePropertyChanged(); 
            }
        }

        public MainViewModel()
        {
            this.Tasks = new ObservableCollection<Task>();
            this.SelectedDate = DateTime.Now;
            this.Name = "";
            this.Tasks.CollectionChanged += refreshTasksDone;
            AddCommand = new RelayCommand(() => AddClick());
            DeleteAllCommand = new RelayCommand(() => DeleteClickAll());
            DeleteCommand = new RelayCommand(() => DeleteClick());
            if (IsInDesignMode) {
                this.Tasks.Add(new Task { Name = "Tache1", DateTask = DateTime.Now, IsDone = false });
                this.Tasks.Add(new Task { Name = "Tache2", DateTask = DateTime.Now, IsDone = true });
            }
            else {
                this.Tasks.Add(new Task { Name = "Tache1", DateTask = DateTime.Now, IsDone = false });
                this.Tasks.Add(new Task { Name = "Tache2", DateTask = DateTime.Now, IsDone = true });
            }
        }

        private void AddClick()
        {
            Task task = new Task();
            task.DateTask = this.SelectedDate;
            task.Name = this.Name;
            task.IsDone = false;
            this.Tasks.Add(task);
            this.Name = "";
            this.SelectedDate = DateTime.Now;
        }

        private void DeleteClickAll()
        {
            this.Tasks.Clear();
        }

        private void DeleteClick() {
            Console.WriteLine(this.SelectedTask.Name);
            this.Tasks.Remove(this.SelectedTask);
        }

        private void refreshTasksDone(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("POUET");
            this.TasksDone = this.Tasks.Where(t => t.IsDone == true).Count();
        }
    }
}