﻿#pragma checksum "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Ajouter_Menu.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "097F03BCDE1A87D47E4167A2B9C691CCA582F482"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.MahApps;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using WPFood.Vues.UC_Admin;


namespace WPFood.Vues.UC_Admin {
    
    
    /// <summary>
    /// Modale_Ajouter_Menu
    /// </summary>
    public partial class Modale_Ajouter_Menu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 34 "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Ajouter_Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbNomMenu;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Ajouter_Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbCategorie;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Ajouter_Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbSaison;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Ajouter_Menu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAjout;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WPFood;component/vues/uc_admin/menu%20et%20items/modale_ajouter_menu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Ajouter_Menu.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 26 "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Ajouter_Menu.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txbNomMenu = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Ajouter_Menu.xaml"
            this.txbNomMenu.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.changementDeTexte);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cmbCategorie = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.cmbSaison = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.btnAjout = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Ajouter_Menu.xaml"
            this.btnAjout.Click += new System.Windows.RoutedEventHandler(this.btn_AjouterUnMenu);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

