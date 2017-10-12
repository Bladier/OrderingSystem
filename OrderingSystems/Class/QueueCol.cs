	using Microsoft.VisualBasic;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Data;
	using System.Drawing;
	using System.Diagnostics;
	using System.Windows.Forms;
	using System.Linq;
	using System.Xml.Linq;

namespace OrderingSystems.Class
{
    class QueueCol : System.Collections.CollectionBase
    {
        int index;
        public QueueLines Item

        {
            // The appropriate item is retrieved from the List object and 
            // explicitly cast to the Widget type, then returned to the 
            // caller.

            get { return (QueueLines)List[index]; }
        }

        public void Add(QueueLines IDCard)
        {
            // Invokes Add method of the List object to add a widget.
            List.Add(IDCard);
        }

        public void Remove(int index)
        {
            // Check to see if there is a widget at the supplied index.
            if (index > Count - 1 | index < 0)
            {
                // If no widget exists, a messagebox is shown and the operation is 
                // cancelled.
                System.Windows.Forms.MessageBox.Show("Index not valid!");
            }
            else
            {
                // Invokes the RemoveAt method of the List object.
                List.RemoveAt(index);
            }

        }
    }
    }

