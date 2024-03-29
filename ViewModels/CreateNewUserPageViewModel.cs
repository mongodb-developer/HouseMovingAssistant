﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace HouseMovingAssistant.ViewModels
{
    //TODO Is this used?
    public partial class CreateNewUserPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private string firstName;

        [ObservableProperty]
        private string lastName;

        [ObservableProperty]
        private string emailText = "";

        [ObservableProperty]
        private string passwordText = "";

        public string fullName => firstName + " " + LastName;

        [RelayCommand]
        public async Task CreateUser()
        {
            try
            {
                await App.RealmApp.EmailPasswordAuth.RegisterUserAsync(EmailText, PasswordText);               

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error creating account!", "Error: " + ex.Message, "OK");
            }
        }
    }
}
