﻿#pragma checksum "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Modifier_Item.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C8E24B58DE944353C904882AF71739055CC96505"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

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
using WPFood.Vues.UC_Admin.Menu_et_Items;


namespace WPFood.Vues.UC_Admin.Menu_et_Items {
    
    
    /// <summary>
    /// Modale_Modifier_Item
    /// </summary>
    public partial class Modale_Modifier_Item : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Modifier_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbNomItem;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Modifier_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbxCategorieItem;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Modifier_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txbPrixItem;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Modifier_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnModifierImage;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Modifier_Item.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbImageName;
        
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
            System.Uri resourceLocater = new System.Uri("/WPFood;component/vues/uc_admin/menu%20et%20items/modale_modifier_item.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Modifier_Item.xaml"
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
            
            #line 27 "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Modifier_Item.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txbNomItem = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.cbxCategorieItem = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.txbPrixItem = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnModifierImage = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Modifier_Item.xaml"
            this.btnModifierImage.Click += new System.Windows.RoutedEventHandler(this.btnModifierImage_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.tbImageName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 62 "..\..\..\..\..\..\Vues\UC_Admin\Menu et Items\Modale_Modifier_Item.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.btnClick_ModifierItem);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

