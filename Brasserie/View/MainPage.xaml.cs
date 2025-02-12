﻿using Brasserie.Model;
using Brasserie.Model.Restaurant.Catering;
using Brasserie.Model.Restaurant.People;
using Brasserie.Utilities.DataAccess;
using Brasserie.Utilities.DataAccess.Files;
using Brasserie.Utilities.Interfaces;
using Brasserie.Utilities.Services;
using Brasserie.ViewModel;
using System.Collections.ObjectModel;

namespace Brasserie.View
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            myCounter = new Counter();
        }
        public MainPage(MainPageViewModel mainPageVM, IDataAccess dataAccessService,
        IAlertService alertService)
        {
            dataAccess = dataAccessService;
            alert = alertService;
            mainPageViewModel = mainPageVM;
            // Définition du BindingContext avec le ViewModel
            BindingContext = mainPageVM;

            InitializeComponent();
        }
        /// <summary>
        /// Manager to the data access (Csv, Json, XAML, SQL...)
        /// </summary>
        private IDataAccess dataAccess;
        /// <summary>
        /// Manager to the data access (Csv, Json, XAML, SQL...)
        /// </summary>
        private IAlertService alert;
        /// <summary>
        /// keep a reference to the ViewModel for eventual testings
        /// </summary>
        private MainPageViewModel mainPageViewModel;

        Counter myCounter;

        public StaffMembersCollection SaffMemberCollection { get; private set; }

        

        private void OnCounterClicked(object sender, EventArgs e)
        {

            myCounter.IncrementCounter();


            EntryCount.Text = myCounter.CounterValue.ToString();
            //texte de la case de clics ↓↓↓
            CounterBtn.Text = "Nombre de Clics :" + myCounter.CounterValue.ToString();

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void buttonTestCreateFirstPersons_Clicked(object sender, EventArgs e)
        {
            //Person firstPerson = new Person(id: 1, lastName: "Beumier", firstName: "Damien", gender: true, email: "dambeumier@gmail.com", mobilePhoneNumber: "0489142293");
            //Person secondPerson = new Person(id: 2, lastName: "Deroisin", firstName: "Sophie", gender: false, email: "sophiederoisin@gmail.com", mobilePhoneNumber: "0473121314");
            //Person thirdPerson = new Person(3, "Jandrin", "Marc", true, "jandrinmarc@gmail.com", mobilePhoneNumber: "0485556678");
            //Person fourthPerson = new Person(4, "Lupant", "Sebasien");
            //Person fifthPerson = new Person();

            //petit ajout perso (réaction au click sur bouton)
            lblDebug.Text = "Personnes Crées";

            //Person p;
            //p = new Person(6, "Tardif", "Jean");


        } //end buttonTestCreateFirstPersons_Clicked


        private void buttonTestEncapsulation_Clicked(object sender, EventArgs e)
        {
            //Person p = new Person(id: 2, lastName: "Deroisin", firstName: "Sophie", gender: false, email: "sophiederoisin@gmail.com", mobilePhoneNumber: "0473121314");
            //p.FirstName = "Marie-Sophie";
            //lblDebug.Text = p.FirstName;

        }

        private void buttonTestStatic_Clicked(object sender, EventArgs e)
        {
            string mail = "monmail@gmail.com";
            bool testMail = Person.CheckEMail(mail);
            //lblDebug.Text = $" résultat du test de validité du mail {mail} : { testMail.ToString()} ";
            lblDebug.Text = $"Nombres d'instances de classe Person : {Person.TotalPersons}";

        }

        private void buttonTestCreateItem_Clicked(object sender, EventArgs e)
        {
            //Item trucComestible = new Item("chose", "c'est comestible", 1, 1.70, 6.50, "comestible.jpg");
            //Item trucBuvable = new Item("machin", "bois", 2, 1.78, 6.47, "buvable.gif");

            //petit ajout perso (réaction au click sur bouton)
            lblDebug.Text = "Item Crées";
        }


        //private void ButtonTestCateringClasses_Clicked(object sender, EventArgs e)
        //{
        //Item trucComestible = new Item("chose", "c'est comestible", 1, 1.70, 6.50, "comestible.jpg");
        //Drink UnDemiBelge = new Drink("Une50", "Un demi mais façon belge", 1, 50, 4.81, 6.07, "UnDemiBelge.jpg");
        //Dish CarbonnadeAuFaro = new Dish("Carbonnade Au Faro", "Carbonnade Sauce Faro , un délice !", 1, 10.45, 6.14, "unebonnecarbonnadefieu.jpg");
        //Soft RomanCola = new Soft("Roman Cola", "Cola Made in Belgium", 1, 33.45, 2.14, 6.12, "UnbonverredeRomanColaGlacé.png");
        //Alcohol EauDeVillee = new Alcohol("Eau de Villée", "Eau de vie de Biercée ", 1, 6.15, 31.25, 7.14, 21.45, "eaudeVillée.jpg");
        //Aperitif MojitoRoyal = new Aperitif("Mojito Royal", "Cocktail Mojito avec ajout de Champagne", 1, 45.12, 21.78, 10.21, 21.14, "mojitoroyal.png ");
        // Beer Orval = new Beer("Orval", "Biere trappiste Orval", 1, 25.11, 8.01, false, true, 5.45, 21.14, "Unbonverredorval.jpg");

        //   lblDebug.Text = "instanciation des 7 classes faites ! ";
        // }


        public void ButtonTestCollection_Clicked(object sender, EventArgs e)
        {
            StaffMember staffm1 = new StaffMember(10, "Vandenberg", "Caroline", true, "carovan@gmail.com", "0476893029", "BE81 7345 1290 1038", "10, rue del'eglise 7030 Ghlin", 3050.0);
            StaffMember staffm2 = new StaffMember(11, "Dries", "Francois", true, "francoisdries@gmail.com", "0485113289", "BE83 2378 9876 2390", "130, rue debinche 7030 Ghlin", 3275.0);
            Manager m = new Manager(12, "Legars", "Flavien", true, "legafla@gmail.com", "0482426671", "BE83 4435 1893 1450", "5, rue de la cle 7000Mons", 5500.0, "Password01");
            ObservableCollection<StaffMember> staffmCol = new ObservableCollection<StaffMember>();
            staffmCol.Add(staffm1);
            staffmCol.Add(staffm2);
            staffmCol.Add(m);
            string s = $"\nnombre d'éléments dans la collection : {staffmCol.Count}";
            foreach (StaffMember sm in staffmCol)
            {
                s += $"\n{sm.FirstName} {sm.LastName} : {sm.GetType().ToString()}";
            }
            lblDebug.Text = s;
        }

        private void ButtonTestLambdasOnCollection_Clicked(object sender, EventArgs e)
        {
            ObservableCollection<Drink> drinks = new ObservableCollection<Drink>();

            drinks.Add(new Soft(1, name: "Coca 25", "", 3.30, "coca.jpg", 21.0, 25));
            drinks.Add(new Soft(2, name: "Fanta 25", "", 3.30, "fanta.jpg", 21.0, 25));
            drinks.Add(new Soft(3, name: "Coca 33", "", 4.20, "coca.jpg", 21.0, 33));
            drinks.Add(new Soft(4, name: "Fanta 33", "", 4.20, "fanta.jpg", 21.0, 33));
            drinks.Add(new Soft(5, name: "Water 25cl", "", 3.10, "water25.jpg", 21.0, 25));
            drinks.Add(new Soft(6, name: "Water 50cl", "", 5.50, "water.jpg", 21.0, 50));
            drinks.Add(new Soft(7, name: "Water 1L", "", 7.00, "water.jpg", 21.0, 100));
            drinks.Add(new Soft(8, name: "Coca Zero", "", 3.50, "coca.jpg", 21.0, 25));
            drinks.Add(new Soft(9, name: "IceTea Zero", "", 3.50, "coca.jpg", 21.0, 25));
            drinks.Add(new Beer(10, name: "Ambrasse Temps 25", "", 4.20, "amb25.jpg", 21.0, 25, 6.00, false, false));
            drinks.Add(new Beer(11, name: "Troll 25", "", 4.20, "troll25.jpg", 21.0, 25.00, 5.50, false, false));
            // match Criteria ?;
            bool boolResult;
            boolResult = drinks.All(d => d.UnitPrice < 8.00);//all elements respect the criteria ?
            boolResult = drinks.Any(d => d.UnitPrice >= 10.00);//exist at least one element that respect the criteria
                                                               //sorted collections
            ObservableCollection<Drink> orderByNameDesc = new ObservableCollection<Drink>(drinks.OrderByDescending(d => d.Name));
            ObservableCollection<Drink> orderByUnitPriceAsc = new ObservableCollection<Drink>(drinks.OrderBy(d => d.UnitPrice));
            //collection with selection
            ObservableCollection<Drink> select25Cl = new ObservableCollection<Drink>(drinks.Where(d => d.Volume == 25.00));
            ObservableCollection<Drink> waters = new ObservableCollection<Drink>(drinks.Where(d => d.Name.Contains("Water")));
            ObservableCollection<Drink> beers = new ObservableCollection<Drink>(drinks.OfType<Beer>());
            //find element with one or more (logical expression) criteria
            Drink coca33 = drinks.First(d => d.Name.Contains("Coca 33"));
            Drink d = drinks.First(d => d.Volume > 25.00 && d.PictureName.EndsWith(".jpg"));
            //build new list from another collection
            List<string> s = drinks.Select(d => $"{d.Id};{d.Name};{d.Description};{d.UnitPrice};{d.Volume}").ToList();
            //compute
            double maxUnitPrice = drinks.Max(d => d.UnitPrice);
            double average = drinks.Average(d => d.UnitPrice);
            double sum = drinks.Sum(d => d.UnitPrice);
            //do something foreach element
            //drinks.ForEach(d => d.VatRate = 22.0);   

        }
        private void buttonExLambdaOnCollection(object sender, EventArgs e)
        {
            ObservableCollection<StaffMember> staff = new ObservableCollection<StaffMember>();
            staff.Add(new StaffMember(1, "Dutrieu", "Pierre", true, "dutrieur@gmail.com", "0498345678", "BE45 6781 2345 2490", "4, rue de la coupe 7000Mons", 34000));
            staff.Add(new StaffMember(2, "Lalande", "Vanessa", false, "", "0485667098", "BE806581 1145 3496", "16, rue de la loi 7080 Nivelles", 32500));
            staff.Add(new Manager(3, "Jenlain", "Fabienne", false, "jenfab23@gmail.com", "0478901322", "BE80 4394 7739 1234", "13, rue de Mons 6000 Beaumont", 59000, "Password01"));
            staff.Add(new StaffMember(4, "Baulieu", "Jean", true, "", "", "BE23 1189 1390 1193", "5, rue des tilleus 7030 Ghlin", 36500));
            staff.Add(new StaffMember(5, "Gerardin", "Isabelle", false, "", "0475671038", "BE801782 4490 9113", "120, rue des drapiers 7000 Mons", 41000));
            staff.Add(new Manager(6, "Balkan", "Fred", true, "balkan@gmail.com", "0479001280", "BE89 1190 1127 2280", "10, rue grande 6340 Nimy", 54000, "TrucMachin01"));
            staff.Add(new StaffMember(7, "Gutierez", "Manolo", true, "manolo140@gmail.com", "0498671011", "BE70 9012 1034 1931", "8, rue de la riviere 7000 Mons", 29800));


            int EmplyeesNumber = staff.Count();
            bool allHaveMobile = staff.All(s => !string.IsNullOrEmpty(s.MobilePhoneNumber));

            //Est-ce qu’il y a un membre injoignable, qui n’a pas de N° de téléphone ni d’Email renseignés ?
            bool isSomeoneUnjoinable = staff.Any(s => string.IsNullOrEmpty(s.MobilePhoneNumber) && string.IsNullOrEmpty(s.Email));

            //Le premier membre (celui du c)) (sa référence) qui n’a pas de N° de téléphone ni d’Email renseignés
            StaffMember firstUnJoingnable = staff.FirstOrDefault(s => string.IsNullOrEmpty(s.MobilePhoneNumber) && string.IsNullOrEmpty(s.Email));

            //La collection des employés n’ayant pas d’email renseigné.
            ObservableCollection<StaffMember> employeWithNoMail = new ObservableCollection<StaffMember>(staff.Where(s => string.IsNullOrEmpty(s.Email)));

            //La collection des employées(de genre féminin).
            ObservableCollection<StaffMember> womens = new ObservableCollection<StaffMember>(staff.Where(s => !s.Gender));

            //La collection des employés résidant à Mons.
            ObservableCollection<StaffMember> liveInMons = new ObservableCollection<StaffMember>(staff.Where(s => !string.IsNullOrEmpty(s.Address) && s.Address.Contains("7000")));

            // La collection des managers
            ObservableCollection<StaffMember> onlyManagers = new ObservableCollection<StaffMember>(staff.OfType<Manager>());

            //La collection des employés triés par ordre alphabétique de nom de famille.
            ObservableCollection<StaffMember> orderByNameAsc = new ObservableCollection<StaffMember>(staff.OrderBy(s => s.LastName));

            //Le pourcentage d’hommes dans le personnel (en une seule ligne de code).
            double pourcentMen = (100 * staff.Count(s => s.Gender)) / staff.Count;

            //Les employés par ordre croissant de salaire.
            //Impossible de récuperer un Protected depuis la main page
        }

        private void buttonTestItemsCollection(object sender, EventArgs e)
        {
            Soft coca = new Soft(1, name: "Coca cola", "", 3.30, "coca.jpg", 21.0, 25);
            Soft fanta = new Soft(2, name: "Fanta", "", 3.30, "fanta.jpg", 21.0, 25);
            Beer brassTemps = new Beer(3, name: "Coca cola", "", 3.30, "biere.jpg", 21.0, 25, 6.0, false, false);
            Dish spaghBolo = new Dish(4, "Spaghetti bolo", "", 15.30, "bolo.jpg", 21.0);
            Soft coca2 = new Soft(5, name: "Coca cola", "", 3.30, "coca.jpg", 21.0, 25);

            ItemsCollection itCol = new ItemsCollection();

            itCol.AddItem(coca);
            itCol.AddItem(fanta);
            itCol.AddItem(brassTemps);
            itCol.AddItem(spaghBolo);
            itCol.AddItem(coca2);//test to add an item who have the same name as another already in the list
            itCol.DeleteItem(brassTemps);//delete one item
            itCol.IndexPrices(5.00); //index 5% all prices
        }

        private void ButtonTestCustomerCollection_Clicked(object sender, EventArgs e)
        {

            Customer riri = new Customer(1, "Duck", "Riri", true, "riri@disney.com", "555-897", Customer.CustomerType.New);
            Customer fifi = new Customer(2, "Duck", "Fifi", true, "fifi@disney.com", "555-898", Customer.CustomerType.Occasional);
            Customer loulou = new Customer(3, "Duck", "Loulou", true, "loulou@disney.com", "555-899", Customer.CustomerType.Regular);
            Customer zaza = new Customer(4, "Duck", "Zaza", false, "zaza@disney.com", "555-900", Customer.CustomerType.Regular);

            CustomersCollection cuscoll = new CustomersCollection();

            cuscoll.AddCustomer(riri);
            cuscoll.AddCustomer(fifi);
            cuscoll.AddCustomer(loulou);
            cuscoll.AddCustomer(zaza);

            string s = "";
            s = $"nombre de clients : {cuscoll.Count}";
            s += $"\nPourcentage nouveaux : {cuscoll.NewCustomersPercentage}";
            s += $"\nPourcentage occasionels : {cuscoll.OccasionalCustomersPercentage}";
            s += $"\nPourcentage réguliers : {cuscoll.RegularCustomersPercentage}";
            lblDebug.Text = s;


        }

        public void ButtonTestReadWriteTextFileWithList(object sender, EventArgs e)
        {
            string csvFilePath = @"C:\POO\MAUI\Brasserie_OO_IramPs-master\Brasserie\Configuration\Datas\Csv\Persons.csv";
            List<string> personsList = new List<string>(); // Créer une collection vide de chaînes
            personsList = File.ReadAllLines(csvFilePath).ToList(); // Copier chaque ligne dans la collection

            // Afficher le contenu de la collection
            string s = "";
            foreach (string line in personsList)
            {
                s += $"\n{line}";
            }
            lblDebug.Text = s;

            // Ajouter des personnes à la collection
            personsList.Add("Customer;10;Maggi;Toni;true;maggiton@gmail.com;0491609830;Occasional");
            personsList.Add("Customer;11;Fernez;Jean;true;jeanfernez@gmail.com;0480458801;Regular");

            // Écrire toutes les lignes dans un nouveau fichier CSV
            File.WriteAllLines(@"C:\POO\MAUI\Brasserie_OO_IramPs-master\Brasserie\Configuration\Datas\Csv\PersonsRewrite.csv", personsList);
        }

        public void buttonTestPolymorphism(object sender, EventArgs e)
        {
            Beer brasseTemps = new Beer(3, name: "Brasse Temps", "", 3.30, "biere.jpg", 21.0, 25, 6.0, false, false);
            Alcohol al = brasseTemps;
            Drink d = brasseTemps;
            Item it = brasseTemps;

            lblDebug.Text = it.GetType().ToString();

            Beer b = (Beer)it;
        }

        public void buttonTestNew(object sender, EventArgs e)
        {
            StaffMember Lalande = new StaffMember(2, "Lalande", "Vanessa", false, "", "0485667098", "BE80 6581 1145 3496", "16, rue de la loi 7080 Nivelles", 4000);
            Manager Jenlain = new Manager(3, "Jenlain", "Fabienne", false, "jenfab23@gmail.com", "0478901322", "BE80 4394 7739 1234", "13, rue de Mons 6000 Beaumont", 4000, "Password01");

            lblDebug.Text += $"\n Calcul du salaire depuis une référence de StaffMember pour {Lalande.LastName} : {Lalande.WageCalculation()}";
            lblDebug.Text += $"\n Calcul du salaire depuis une référence de Manager pour {Jenlain.LastName} : {Jenlain.WageCalculation()}";

            List<StaffMember> staff = new List<StaffMember>();
            staff.Add(Lalande);
            staff.Add(Jenlain);

            staff.ToList().ForEach(s => lblDebug.Text += $"\n Salaire de {s.LastName} de type {s.GetType()}: {s.WageCalculation()}");

        }

        private void ButtonTestInterfaceAndDataAcces_Clicked(object sender, EventArgs e)
        {
            string CONFIG_FILE = @"C:\Users\Ai\source\repos\Brasserie\Brasserie\Configuration\Datas\Config.txt";
            DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
            DataAccessCsvFile daCsv = new DataAccessCsvFile(dataFilesManager);
            ItemsCollection items = daCsv.GetAllItems();
            items.ToList().ForEach(it => lblDebug.Text += $"\n Item: {it.Name} - prix{it.UnitPrice.ToString()}€ - {it.AutoDescription()}");


            CustomersCollection customers = daCsv.GetAllCustomers();
            customers.ToList().ForEach(c => lblDebug.Text += $"\n Client:{c.Id} {c.FirstName}{c.LastName}");


        }

        private void ButtonTestInterfaceAndDataAccesStaffManager_Clicked(object sender, EventArgs e)
        {
            string CONFIG_FILE = @"C:\Users\Ai\source\repos\Brasserie\Brasserie\Configuration\Datas\ConfigCSV.txt";
            DataFilesManager dataFilesStaffMember = new DataFilesManager(CONFIG_FILE);
            DataAccessCsvFile daCsv = new DataAccessCsvFile(dataFilesStaffMember);
            StaffMembersCollection staffMember = daCsv.GetAllStaffMembers();
            staffMember.ToList().ForEach(st => lblDebug.Text += $"\n {st.GetType} - prénom : {st.FirstName} - Nom{st.LastName} ");


            StaffMembersCollection staffMembers = daCsv.GetAllStaffMembers();
            staffMember.ToList().ForEach(c => lblDebug.Text += $"\n Client:{c.Id} {c.FirstName}{c.LastName}");
        }

        private void ButtonTestDataAccessJsonFile_Clicked(object sender, EventArgs e)
        {
            string CONFIG_FILE = @"C:\Users\Ai\source\repos\Brasserie\Brasserie\Configuration\Datas\ConfigJson.txt";
            DataFilesManager dataFilesManager = new DataFilesManager(CONFIG_FILE);
            DataAccessJsonFile da = new DataAccessJsonFile(dataFilesManager);
            ItemsCollection items = da.GetAllItems();
            items.ToList().ForEach(it => lblDebug.Text += $"\n Item: {it.Name} - prix {it.UnitPrice.ToString()}€ - {it.AutoDescription()}");
            items[0].Description = "on a change la description du 1er item";
            items[5].UnitPrice = 99.9; //changement du prix du 6ème item
                                       //sauvegarde des données 
            da.UpdateAllItemsDatas(items);


        }
        private async void ButtonTestDisplayAlert_Clicked(object sender, EventArgs e)
        {
            AlertServiceDisplay alertService = new AlertServiceDisplay();
            await alertService.ShowAlert("Titre de mon pop up", "voici un exemple d'alerte");
            if (await alertService.ShowConfirmation("Questionnaire", "Etes-vous d'accord de répondre à une question ? ", "Oui je suis d'accord", "Non pas maintenant"))
            {
                var userEntry = await alertService.ShowPrompt("Saisie du nom", "Votre prénom ? ");
                var userChoice = await alertService.ShowQuestion("Votre brasserie préférée ? ", "ORVAL", "ST FEUILLIEN", "CHIMAY");
                await alertService.ShowAlert("Choix brasserie", $" Merci {userEntry} , voici votre choix: {userChoice}");
            }


        }
        

    }



}
