using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoloTour.DataAcesss.Interfaces
{
    public interface IIdAndTitleObject
    {
        /// <summary>
        /// Gets the ID of this instance.
        /// </summary>
        /// <value>
        /// The ID of this instance.
        /// </value>
        int Id { get; }
        /// <summary>
        /// Gets the Title of this instance.
        /// </summary>
        /// <value>
        /// The ID of Title instance.
        /// </value>
        string Title { get; }
    }
}
