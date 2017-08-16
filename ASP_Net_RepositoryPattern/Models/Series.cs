using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Http.Results;
using System.Web.UI.WebControls;

namespace ASP_Net_RepositoryPattern.Models
{
    /// <summary>
    /// The annotations in this class are not neccessary because the model follows
    /// the conventions of EF. However they demonstrate a way to annotate properties
    /// if this is not the case.
    /// </summary>
    public class Series
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100, ErrorMessage = "The title of the series has to be shorter than 100 characters")]
        public string Title { get; set; }
        public int Season { get; set; }
        [Column("Episode")]
        public int Episode { get; set; }

        // This property can be dynamically genereated and does not have to be stored in the data base
        [NotMapped]
        public string SeriesCode => Title.Length > 2 ? Title.Substring(0, 3) : Title;
    }
}