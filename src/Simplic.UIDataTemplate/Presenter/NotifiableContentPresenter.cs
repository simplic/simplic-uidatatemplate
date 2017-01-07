using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Delegate for content changed events
    /// </summary>
    /// <param name="sender">Sender</param>
    /// <param name="e">Arguments</param>
    public delegate void ContentChangedEventHandler(object sender, ContentChangedEventArgs e);

    /// <summary>
    /// <see cref="ContentPresenter"/> which notifies content changes
    /// </summary>
    public class NotifiableContentPresenter : ContentPresenter
    {
        /// <summary>
        /// Content changed event
        /// </summary>
        public static RoutedEvent ContentChangedEvent = EventManager.RegisterRoutedEvent("ContentChanged", RoutingStrategy.Bubble, typeof(ContentChangedEventHandler), typeof(NotifiableContentPresenter));

        /// <summary>
        /// Public event handler for ContentChanged event
        /// </summary>
        public event ContentChangedEventHandler ContentChanged
        {
            add { AddHandler(ContentChangedEvent, value); }
            remove { RemoveHandler(ContentChangedEvent, value); }
        }

        /// <summary>
        /// Add routeted event handler
        /// </summary>
        /// <param name="el"></param>
        /// <param name="handler"></param>
        public static void AddContentChangedHandler(UIElement el, ContentChangedEventHandler handler)
        {
            el.AddHandler(ContentChangedEvent, handler);
        }

        /// <summary>
        /// Remove routed event handler
        /// </summary>
        /// <param name="el"></param>
        /// <param name="handler"></param>
        public static void RemoveContentChangedHandler(UIElement el, ContentChangedEventHandler handler)
        {
            el.RemoveHandler(ContentChangedEvent, handler);
        }

        /// <summary>
        /// Raise event when the <see cref="ContentPresenter"/> content has changed
        /// </summary>
        /// <param name="visualAdded">Added items</param>
        /// <param name="visualRemoved">Removed items</param>
        protected override void OnVisualChildrenChanged(System.Windows.DependencyObject visualAdded, System.Windows.DependencyObject visualRemoved)
        {
            base.OnVisualChildrenChanged(visualAdded, visualRemoved);
            RaiseEvent(new ContentChangedEventArgs(ContentChangedEvent, this, visualAdded, visualRemoved));
        }
    }
}
