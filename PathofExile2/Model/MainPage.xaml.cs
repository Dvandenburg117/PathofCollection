
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace PathofExile2
{
    public partial class MainPage : ContentPage
    {
        private IEnumerable<Weapon> _weapons;
    
        public MainPage()
        {
            InitializeComponent();

            weaponList.ItemsSource = _weapons;
        }      

        private void weaponList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var weapon = e.Item as Weapon;
            DisplayAlert(weapon.weaponName, weapon.weaponNote, "OK");
        }

        //leave this out since for now it has the same functionality as the above function
        /*private void weaponList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var weapon = e.SelectedItem as Weapon;
            DisplayAlert(weapon.weaponName, weapon.weaponNote, "OK");
        }*/

        
        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var weapon = menuItem.CommandParameter as Weapon;
            DisplayAlert(weapon.weaponName, "Go to Wiki Page?", "Yes", "No");
        }
        

        private void MenuItem_Deleted(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var weapon = menuItem.CommandParameter as Weapon;
            DisplayAlert(weapon.weaponName, "Delete Item?", "Yes", "No");
        }

        //try and see if this bunch of code can be moved to another file for overall readability 
        IEnumerable<WeaponGroup> GetWeapons2(string searchText = null) {

            var weapons = new List<WeaponGroup>{

                new WeaponGroup("Two-Handed Sword")
                {
                    new Weapon {
                        weaponType = "Two-Handed Sword",
                        weaponName = "Corroded Blade",
                        imageURL = "https://static.wikia.nocookie.net/pathofexile_gamepedia/images/0/02/Corroded_Blade_inventory_icon.png/revision/latest/scale-to-width-down/39?cb=20160723005912",
                        weaponNote = "Despite being a two-handed weapon, Corroded Blades can only have up to three sockets."
                    },
                    new Weapon {
                        weaponType = "Two-Handed Sword",
                        weaponName = "Exquisite Blade",
                        imageURL = "https://static.wikia.nocookie.net/pathofexile_gamepedia/images/a/af/Exquisite_Blade_inventory_icon.png/revision/latest/scale-to-width-down/78?cb=20160723010612",
                        weaponNote = "Base Crit Chance is now 5.7% (from 6%), Implicit now grants +50% to Global Critical Strike Multiplier (from 60%)"
                    },
                    new Weapon
                    {
                        weaponType = "Two-Handed Sword",
                        weaponName = "Longsword",
                        imageURL = "https://static.wikia.nocookie.net/pathofexile_gamepedia/images/2/28/Longsword_inventory_icon.png/revision/latest/scale-to-width-down/78?cb=20160723011932",
                        weaponNote = "There are currently no unique items for this base item type."
                    },
                    new Weapon
                    {
                        weaponType = "Two-Handed Sword",
                        weaponName = "Bastard Sword",
                        imageURL = "https://static.wikia.nocookie.net/pathofexile_gamepedia/images/7/7f/Bastard_Sword_inventory_icon.png/revision/latest/scale-to-width-down/78?cb=20160723005312",
                        weaponNote = "Implicits that granted 40% increased Global Accuracy Rating now grant 60% increased Global Accuracy Rating."
                    },
                    new Weapon
                    {
                        weaponType = "Two-Handed Sword",
                        weaponName = "Ornate Sword",
                        imageURL = "https://static.wikia.nocookie.net/pathofexile_gamepedia/images/6/64/Ornate_Sword_inventory_icon.png/revision/latest/scale-to-width-down/78?cb=20160723012232",
                        weaponNote = "Implicit mod changed to +185 to accuracy rating (previously 18% increased Accuracy Rating)."
                    },
                },
                new WeaponGroup("Rapier")
                {
                    new Weapon {
                        weaponType = "Rapier",
                        weaponName = "Daresso's Passion",
                        imageURL = "https://static.wikia.nocookie.net/pathofexile_gamepedia/images/1/1f/Daresso%27s_Passion_inventory_icon.png/revision/latest/scale-to-width-down/39?cb=20160307082157",
                        weaponNote = "(60-80)% increased Damage while you have no Frenzy Charges"
                    },
                    new Weapon {
                        weaponType = "Rapier",
                        weaponName = "Elegant Foil",
                        imageURL = "https://static.wikia.nocookie.net/pathofexile_gamepedia/images/8/80/Elegant_Foil_inventory_icon.png/revision/latest/scale-to-width-down/39?cb=20160723010443",
                        weaponNote = "Implicit mod reduced to +25% to Global Critical Strike Multiplier (down from +30%)."
                    },
                    new Weapon {
                        weaponType = "Rapier",
                        weaponName = "Hook Sword",
                        imageURL = "https://static.wikia.nocookie.net/pathofexile_gamepedia/images/3/36/Hook_Sword_inventory_icon.png/revision/latest/scale-to-width-down/78?cb=20160723011332",
                        weaponNote = "Implicit mod increased to 4% chance to Dodge Attacks (up from 2%)."
                    }
                },
                new WeaponGroup("Mace")
                {
                    new Weapon {
                        weaponType = "One-Handed Mace",
                        weaponName = "Gorebreaker",
                        imageURL = "https://static.wikia.nocookie.net/pathofexile_gamepedia/images/9/93/Gorebreaker_inventory_icon.png/revision/latest/scale-to-width-down/39?cb=20150703123717",
                        weaponNote = "Sure, there's many a hard man out there. But this'll soften them up."
                    },
                    new Weapon {
                        weaponType = "One-Handed Mace",
                        weaponName = "Wyrm Mace",
                        imageURL = "https://static.wikia.nocookie.net/pathofexile_gamepedia/images/1/1c/Wyrm_Mace_inventory_icon.png/revision/latest/scale-to-width-down/78?cb=20160723014202",
                        weaponNote = "Using a Blessed Orb on a legacy Ornate Mace with the implicit modifier 40% increased Stun Duration on Enemies will increase the value of that modifier to 45%."
                    },
                    new Weapon {
                        weaponType = "One-Handed Mace",
                        weaponName = "Rock Breaker",
                        imageURL = "https://static.wikia.nocookie.net/pathofexile_gamepedia/images/e/e4/Rock_Breaker_inventory_icon.png/revision/latest/scale-to-width-down/78?cb=20160723012713",
                        weaponNote = "Implicit mod changed to 15% reduced Enemy Stun Threshold (previously 40% increased Stun Duration on Enemies)."
                    }
                }
            };

            if (String.IsNullOrWhiteSpace(searchText))
                return weapons;

            return weapons.Where(c  => c.weaponClass.StartsWith(searchText));
        }

        private void weaponList_Refreshing(object sender, EventArgs e)
        {
            weaponList.ItemsSource = GetWeapons2();

            weaponList.EndRefresh();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            weaponList.ItemsSource = GetWeapons2(e.NewTextValue);
        }

        //Still figuring out if there is an easier way to implement getWeapons
        /*IEnumerable<Weapon> GetWeapons(string searchText = null)
        {

            _weapons = new List<Weapon> {
                    new Weapon {
                        weaponType = "Two-Handed Sword",
                        weaponName = "Corroded Blade",
                        imageURL = "https://static.wikia.nocookie.net/pathofexile_gamepedia/images/0/02/Corroded_Blade_inventory_icon.png/revision/latest/scale-to-width-down/39?cb=20160723005912"
                    },
                    new Weapon {
                        weaponType = "Two-Handed Sword",
                        weaponName = "Exquisite Blade",
                        imageURL = "https://static.wikia.nocookie.net/pathofexile_gamepedia/images/a/af/Exquisite_Blade_inventory_icon.png/revision/latest/scale-to-width-down/78?cb=20160723010612"
                    },
                    new Weapon {
                        weaponType = "Rapier",
                        weaponName = "Daresso's Passion",
                        imageURL = "https://static.wikia.nocookie.net/pathofexile_gamepedia/images/1/1f/Daresso%27s_Passion_inventory_icon.png/revision/latest/scale-to-width-down/39?cb=20160307082157"
                    },
                    new Weapon {
                        weaponType = "One-Handed Mace",
                        weaponName = "Gorebreaker",
                        imageURL = "https://static.wikia.nocookie.net/pathofexile_gamepedia/images/9/93/Gorebreaker_inventory_icon.png/revision/latest/scale-to-width-down/39?cb=20150703123717"
                    }

            };
        
            if (String.IsNullOrWhiteSpace(searchText))
                return _weapons;

            return _weapons.Where(c => c.weaponName.StartsWith(searchText));
        }
        */

        //code below is for api connections, make sure to reinstall http and json packages if this comes back into play
        /*
           protected override async void OnAppearing()
       {
           var content = await _client.GetStringAsync(Url);
           var idk = JsonConvert.DeserializeObject<List<Weapon>>(content);
           _apiWeapons = new ObservableCollection<Weapon>(idk);

           weaponList.ItemsSource = _apiWeapons;

           base.OnAppearing();
       }
       */

        //private Weapon weapon;
        //private const string Url = "http://www.pathofexile.com/api/public-stash-tabs";
        //private HttpClient _client = new HttpClient();
        //private ObservableCollection<Weapon> _apiWeapons;
    }
}
