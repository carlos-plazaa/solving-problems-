using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Presentation.ViewModels.MVVNLight;
using Service.Data;
using Service.CRUD;

namespace Presentation.ViewModels
{
    public class ClientItemViewModel : ViewModelBase
    {
        private int clientID;
        private string name;
        private string surname;

        private ClientCRUD service;
        private ICommand updateCommand;

        public ClientItemViewModel(int clientID, string name, string surname)
        {
            this.clientID = clientID;
            this.name = name;
            this.surname = surname;
        }

        public ClientItemViewModel()
        {
            service = new ClientCRUD();
            updateCommand = new RelayCommand(e => { UpdateClient(); }, c => CanUpdate);
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

        public string Name
        {
            get => name;
            set
            {
                name = value;

                OnPropertyChanged(nameof(name));
            }
        }

        public string Surname
        {
            get => surname;
            set
            {
                surname = value;

                OnPropertyChanged(nameof(surname));
            }
        }

        public ICommand UpdateCommand
        {
            get => updateCommand;
        }

        public bool CanUpdate => !(
            string.IsNullOrWhiteSpace(clientID.ToString()) ||
            string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(surname)
        );

        private void UpdateClient()
        {
            service.UpdateClientName(clientID, name);
            service.UpdateClientSurname(clientID, surname);
        }
    }
}
