using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Eventargs which will be used for <see cref="NotifiableContentPresenter"/> ContentChanged event
    /// </summary>
    public class ContentChangedEventArgs : RoutedEventArgs
    {
        /// <summary>
        /// Initialize event
        /// </summary>
        /// <param name="routedEvent">Event instance</param>
        /// <param name="source">Event source</param>
        public ContentChangedEventArgs(RoutedEvent routedEvent, object source, DependencyObject visualAdded, DependencyObject visualRemoved) : base(routedEvent, source)
        {
            this.VisualAdded = visualAdded;
            this.VisualRemoved = visualRemoved;
        }

        /// <summary>
        /// Gets or sets the added item
        /// </summary>
        public DependencyObject VisualAdded
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the removed item
        /// </summary>
        public DependencyObject VisualRemoved
        {
            get;
            private set;
        }
    }
}
