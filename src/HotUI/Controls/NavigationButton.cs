﻿using System;
namespace HotUI {
	public class NavigationButton : ContentView {
		public NavigationButton(Func<View> destination)
		{
			Destination = destination;
		}
		public NavigationButton (Func<string> text,Func<View> destination)
		{
			Content = new Button (text) {
				OnClick = Navigate,
			};

			Destination = destination;
		}
		public NavigationButton (string text, Func<View> destination)
		{
			Content = new Button (text) {
				OnClick = Navigate,
			};
			Destination = destination;
		}

		public Func<View> Destination { get; }
		protected override View GetRenderView ()
		{
			if (Content == null)
				throw new Exception ("You are required to pass in Test or a Body");
			return base.GetRenderView ();
		}

		public void Navigate()
		{
			var view = Destination?.Invoke ();
			//TODO: Check if modal type;
			if(this.Navigation != null) {
				Navigation.Navigate.Invoke(view);
			} else {
				NavigationView.NavigateModal ((this,view));
			}
		}
	}
}
