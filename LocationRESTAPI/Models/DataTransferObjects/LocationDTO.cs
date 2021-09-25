namespace LocationRESTAPI.Models.DataTransferObjects
{
    /// <summary>
    /// Location data transfer object
    /// </summary>
    public class LocationDTO
    {
        /// <summary>
        /// Latitude in degrees
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude in degrees
        /// </summary>
        public double Longitude { get; set; }
    }
}
