using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using poc_maui.Models;

namespace poc_maui.ViewModels
{
	public class MainPageViewModel : BaseViewModel
	{
        #region Constructor
        public MainPageViewModel()
		{
            GetTabs();
        }

        #endregion

        #region Private Properties

        private bool _isParentRecordTabVisible = true;
        private bool _isAdditionalInfoTabVisible;

        private ObservableCollection<TabViewModel> _tabs { get; set; }
        private TabViewModel _selectedTab { get; set; }

        #endregion

        #region Public Properties

        public bool IsParentRecordTabVisible
        {
            get => _isParentRecordTabVisible;
            set { _isParentRecordTabVisible = value; OnPropertyChanged(nameof(IsParentRecordTabVisible)); }
        }

        public bool IsAdditionalInfoTabVisible
        {
            get => _isAdditionalInfoTabVisible;
            set { _isAdditionalInfoTabVisible = value; OnPropertyChanged(nameof(IsAdditionalInfoTabVisible)); }
        }

        public ObservableCollection<TabViewModel> Tabs
        {
            get => _tabs;
            set { _tabs = value; OnPropertyChanged(nameof(Tabs)); }
        }

        public TabViewModel SelectedTab
        {
            get => _selectedTab;
            set
            {
                _selectedTab = value;
                SetSelection();
                OnPropertyChanged(nameof(SelectedTab));
            }
        }

        #endregion

        public ICommand TabChangedCommand { get { return new Command<TabViewModel>(ChangeTabClick); } }

        #region Private Methods

        private void SetSelection()
        {
            foreach (var item in Tabs)
            {
                item.IsSelected = false;
            }

            SelectedTab.IsSelected = true;

            switch (SelectedTab.TabId)
            {
                case 1:
                    IsParentRecordTabVisible = true;
                    IsAdditionalInfoTabVisible = false;
                    break;
                case 2:
                    IsParentRecordTabVisible = false;
                    IsAdditionalInfoTabVisible = true;
                    break;
            }
        }

        private void GetTabs()
        {
            Tabs = new ObservableCollection<TabViewModel>();
            Tabs.Add(new TabViewModel { TabId = 1, IsSelected = true, TabTitle = "Parent record" });
            Tabs.Add(new TabViewModel { TabId = 2, TabTitle = "Additional Info" });
            Tabs.Add(new TabViewModel { TabId = 3, TabTitle = "Contacts" });
            Tabs.Add(new TabViewModel { TabId = 4, TabTitle = "Previous inspections" });
            Tabs.Add(new TabViewModel { TabId = 5, TabTitle = "Attachments" });

            SelectedTab = Tabs.FirstOrDefault();
        }

        private void ChangeTabClick(TabViewModel tab)
        {
            //Tabs.ToList().ForEach(vm => vm.IsSelected = false);
            //SelectedTab.IsSelected = true;

            Tabs.All((arg) =>
            {
                if (arg.TabId == tab.TabId)
                {
                    arg.IsSelected = true;
                }
                else
                {
                    arg.IsSelected = false;
                }
                return true;
            });
            SelectedTab = Tabs.Where(t => t.IsSelected == true).FirstOrDefault();

            switch (SelectedTab.TabId)
            {
                case 1:
                    IsParentRecordTabVisible = true;
                    IsAdditionalInfoTabVisible = false;
                    break;
                case 2:
                    IsParentRecordTabVisible = false;
                    IsAdditionalInfoTabVisible = true;
                    break;
            }
        }

        #endregion
    }
}

