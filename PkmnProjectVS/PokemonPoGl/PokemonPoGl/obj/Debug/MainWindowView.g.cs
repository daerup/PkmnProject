﻿#pragma checksum "..\..\MainWindowView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2C2930F6EB9F4B5991535CF88AEC4368228FADDD"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PokemonPoGl;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using WpfAnimatedGif;
using smoothBar;


namespace PokemonPoGl {
    
    
    /// <summary>
    /// MainWindowView
    /// </summary>
    public partial class MainWindowView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImgPlayerPokemon;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImgEnemyPokemon;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal smoothBar.SmoothProgressBar PlayerHp;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal smoothBar.SmoothProgressBar EnemyHp;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Stab;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Normal;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TxtPlayerPokemon;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TxtEnemyPokemon;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\MainWindowView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Narrator;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PokemonPoGl;component/mainwindowview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindowView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ImgPlayerPokemon = ((System.Windows.Controls.Image)(target));
            
            #line 22 "..\..\MainWindowView.xaml"
            this.ImgPlayerPokemon.AddHandler(WpfAnimatedGif.ImageBehavior.AnimationLoadedEvent, new System.Windows.RoutedEventHandler(this.ImgPlayerPokemon_OnAnimationLoaded));
            
            #line default
            #line hidden
            return;
            case 2:
            this.ImgEnemyPokemon = ((System.Windows.Controls.Image)(target));
            
            #line 23 "..\..\MainWindowView.xaml"
            this.ImgEnemyPokemon.AddHandler(WpfAnimatedGif.ImageBehavior.AnimationLoadedEvent, new System.Windows.RoutedEventHandler(this.ImgEnemyPokemon_OnAnimationLoaded));
            
            #line default
            #line hidden
            return;
            case 3:
            this.PlayerHp = ((smoothBar.SmoothProgressBar)(target));
            return;
            case 4:
            this.EnemyHp = ((smoothBar.SmoothProgressBar)(target));
            return;
            case 5:
            this.Stab = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\MainWindowView.xaml"
            this.Stab.Click += new System.Windows.RoutedEventHandler(this.Stab_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Normal = ((System.Windows.Controls.Button)(target));
            
            #line 80 "..\..\MainWindowView.xaml"
            this.Normal.Click += new System.Windows.RoutedEventHandler(this.Normal_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TxtPlayerPokemon = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.TxtEnemyPokemon = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.Narrator = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

