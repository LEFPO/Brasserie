﻿using Brasserie.Model.Restaurant.Catering;
using Brasserie.Utilities.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brasserie.ViewModel
{
    public partial class MainPageViewModel : BaseViewModel
    {
       
        public MainPageViewModel(IDataAccess dataAccessService, IAlertService
        alertService) : base(alertService)
        {
            dataAccess = dataAccessService; // Instance qui vient du Singletone
            Items = dataAccess.GetAllItems(); //get user's collection datas from chosen DataAccessSource(excel, csv, json...).
            //Tables = DataAccess.GetTables(); //get table's collection datas from chosen DataAccessSource (excel, csv, json...).


        }
        /// <summary>
        /// Manager to the data access (Csv, Json, XAML, SQL...)
        /// </summary>
        private IDataAccess dataAccess;
        /// <summary>
        /// Collection of all users in the databse (source file)
        /// </summary>
        public ItemsCollection Items { get; set; }

        [ObservableProperty]
        private Item itemUserSelection;

        [RelayCommand()]
        private async void ShowItemDetails()
        {
            if (itemUserSelection != null)
            {
                await alertService.ShowAlert("Selection", $"Voitre choix:\n{ ItemUserSelection.Name}\n " +


                $"{ItemUserSelection.Description}\n{ItemUserSelection.PictureName}\n{ItemUserSelection.UnitPrice}€");
            }
            else
            {
                await alertService.ShowAlert("Error", "No item selection");
            }
        }

        [RelayCommand()]
        private void IndexPrices()
        {
            Items.IndexPrices(5.0);
        }
        [RelayCommand()]
        private async void TestBindingShowProperties()
        {
            await alertService.ShowAlert("Infos Resto ", $"En interne, les valeur des propriétés sont: " +
           

           $"\n{MainInfos.Name}\n{MainInfos.Address}\n{MainInfos.WebSite}\n{MainInfos.VatCode}")
           ;
        }
        [RelayCommand()]
        private async void TestBindingChangeProperties()
        {
            MainInfos.Name = "Iram Ps Food";
            MainInfos.Address = "4, rue du grand jour 7131 Beaumont";
            MainInfos.WebSite = "http://irampsfoodservice.com";
            MainInfos.VatCode = "BE 0202.239.951";
        }

    }
}
