using Presentation.ViewModels.MVVNLight;
using Service.CRUD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Presentation.ViewModels
{
    public class EventListViewModel : ViewModelBase
    {
        private int eventID;
        private int clientID;
        private int productID;
        private DateTime purchaseDate;

        private ICommand addCommand;
        private ICommand deleteCommand;

        private EventCRUD service;
        private ObservableCollection<EventItemViewModel> eventViewModels;
        private EventItemViewModel selectedViewModel;
        private bool isEventViewModelSelected;

        public EventListViewModel()
        {
            service = new EventCRUD();
            eventViewModels = new ObservableCollection<EventItemViewModel>();

            addCommand = new RelayCommand(e => { AddEvent(); },
                condition => CanAdd);

            deleteCommand = new RelayCommand(e => { DeleteEvent(); },
                condition => EventViewModelIsSelected());

            isEventViewModelSelected = false;

            GetEvents();
        }

        private void AddEvent()
        {
            service.AddEvent(clientID, productID, purchaseDate);
            GetEvents();
        }

        private void DeleteEvent()
        {
            service.DeleteEvent(SelectedVM.EventID);

            GetEvents();
            OnPropertyChanged(nameof(eventViewModels));
        }

        private void GetEvents()
        {
            eventViewModels.Clear();

            foreach (var e in service.GetAllEvents())
            {
                eventViewModels.Add(new EventItemViewModel(e.EventID, e.UserID, e.ProductID, e.PurchaseDate));
            }

            OnPropertyChanged(nameof(eventViewModels));
        }

        private bool EventViewModelIsSelected()
        {
            return !(selectedViewModel is null);
        }

        public int ClientID
        {
            get => clientID;
            set
            {
                clientID = value;

                OnPropertyChanged(nameof(clientID));
            }
        }

        public int EventID
        {
            get => eventID;
            set
            {
                eventID = value;

                OnPropertyChanged(nameof(eventID));
            }
        }

        public int ProductID
        {
            get => productID;
            set
            {
                productID = value;

                OnPropertyChanged(nameof(productID));
            }
        }

        public DateTime PurchaseDate
        {
            get => purchaseDate;
            set
            {
                purchaseDate = value;

                OnPropertyChanged(nameof(purchaseDate));
            }
        }

        public ICommand AddCommand
        {
            get => addCommand;
        }

        public ICommand DeleteCommand
        {
            get => deleteCommand;
        }

        public bool IsEventViewModelSelected
        {
            get => isEventViewModelSelected;
            set
            {
                isEventViewModelSelectedVisibility = value ? Visibility.Visible : Visibility.Hidden;
                isEventViewModelSelected = value;
                OnPropertyChanged(nameof(isEventViewModelSelected));
            }
        }

        private Visibility isEventViewModelSelectedVisibility;

        public Visibility IsEventViewModelSelectedVisibility
        {
            get => isEventViewModelSelectedVisibility;
            set
            {
                isEventViewModelSelectedVisibility = value;
                OnPropertyChanged(nameof(isEventViewModelSelectedVisibility));
            }
        }

        public ObservableCollection<EventItemViewModel> EventViewModels
        {
            get => eventViewModels;

            set
            {
                eventViewModels = value;
                OnPropertyChanged(nameof(eventViewModels));
            }
        }

        public EventItemViewModel SelectedVM
        {
            get => selectedViewModel;
            set
            {
                selectedViewModel = value;
                isEventViewModelSelected = true;
                OnPropertyChanged(nameof(SelectedVM));
            }
        }

        public bool CanAdd => !(
            string.IsNullOrWhiteSpace(eventID.ToString()) ||
            string.IsNullOrWhiteSpace(clientID.ToString()) ||
            string.IsNullOrWhiteSpace(productID.ToString()) ||
            string.IsNullOrWhiteSpace(purchaseDate.ToString())
        );
    }
}
