using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NotiX7.Views.AttachedProperty
{
    public static class NoteAttachedProperty
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.RegisterAttached("Title", typeof(string), typeof(TextBlock), new PropertyMetadata(false));


    }
}
