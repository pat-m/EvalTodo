using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;

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

        public MainViewModel()
        {
            this.Tasks = new ObservableCollection<Task>();

            if (IsInDesignMode) {
                this.Tasks.Add(new Task { Name = "Tache1", DateTask = DateTime.Now, IsDone = false });
                this.Tasks.Add(new Task { Name = "Tache2", DateTask = DateTime.Now, IsDone = true });
            }
           
            else {
                this.Tasks.Add(new Task { Name = "Tache1", DateTask = DateTime.Now, IsDone = false });
                this.Tasks.Add(new Task { Name = "Tache2", DateTask = DateTime.Now, IsDone = true });
            }
        }
    }
}