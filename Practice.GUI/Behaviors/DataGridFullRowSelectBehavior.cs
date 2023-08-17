using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Practice.GUI.Behaviors
{
    internal static class DataGridFullRowSelectBehavior
    {
        #region Dependency Property

        /// <summary>
        /// Forces row selection on empty cell, full row select.
        /// </summary>
        public static readonly DependencyProperty FullRowSelectProperty = DependencyProperty.RegisterAttached("FullRowSelect",
            typeof(bool),
            typeof(DataGridFullRowSelectBehavior),
            new UIPropertyMetadata(false, OnFullRowSelectChanged));

        #endregion

        #region Methods

        /// <summary>
        /// Gets property value.
        /// </summary>
        /// <param name="grid">Frame.</param>
        /// <returns>True if row should be selected when clicked outside of the last cell, otherwise false.</returns>
        public static bool GetFullRowSelect(DataGrid grid)
        {
            return (bool)grid.GetValue(FullRowSelectProperty);
        }

        /// <summary>
        /// Sets property value.
        /// </summary>
        /// <param name="grid">Frame.</param>
        /// <param name="value">Value indicating whether row should be selected when clicked outside of the last cell.</param>
        public static void SetFullRowSelect(DataGrid grid, bool value)
        {
            grid.SetValue(FullRowSelectProperty, value);
        }


        /// <summary>
        /// Occurs when FullRowSelectProperty has changed.
        /// </summary>
        /// <param name="depObj">Dependency object.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnFullRowSelectChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
        {
            DataGrid grid = depObj as DataGrid;
            if (grid == null)
                return;

            if (e.NewValue is bool == false)
            {
                grid.MouseDown -= OnMouseDown;

                return;
            }

            if ((bool)e.NewValue)
            {
                grid.SelectionMode = DataGridSelectionMode.Single;

                grid.MouseDown += OnMouseDown;
            }
        }

        private static void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var dependencyObject = (DependencyObject)e.OriginalSource;

            while ((dependencyObject != null) && !(dependencyObject is DataGridRow))
            {
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            var row = dependencyObject as DataGridRow;
            if (row == null)
            {
                return;
            }

            row.IsSelected = true;
        }

        #endregion
    }
}
