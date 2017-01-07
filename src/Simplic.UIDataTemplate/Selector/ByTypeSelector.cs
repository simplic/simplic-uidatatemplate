using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Simplic.UIDataTemplate
{
    /// <summary>
    /// Selector which select a <see cref="UITemplate"/> by the current viewmodel type
    /// </summary>
    public class ByTypeSelector : DependencyObject, ISelector
    {
        /// <summary>
        /// Contains the type which is requried for the current selector to be valid
        /// </summary>
        public static readonly DependencyProperty DataTypeProperty =
            DependencyProperty.Register("DataType", typeof(Type), typeof(ByTypeSelector), new PropertyMetadata(null));

        /// <summary>
        /// Check whether the passed viewModel is a sub class of <see cref="DataType"/>
        /// If the viewModel instance is null, false will be returned
        /// </summary>
        /// <param name="template">Template instance which should be checked</param>
        /// <param name="viewModel">Viewmodel instance</param>
        /// <returns>True if the viewmodel type mateches</returns>
        public bool SelectTemplate(UITemplate template, object viewModel)
        {
            if (DataType == null)
                throw new Exception("DataType not set for ByTypeSelector.");

            if (viewModel == null)
                return false;

            if (viewModel.GetType() == DataType)
                return true;

            return viewModel.GetType().IsAssignableFrom(DataType);
        }

        /// <summary>
        /// Gets or sets the type which is requried for the current selector to be valid
        /// </summary>
        public Type DataType
        {
            get { return (Type)GetValue(DataTypeProperty); }
            set { SetValue(DataTypeProperty, value); }
        }
    }
}
