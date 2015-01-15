namespace Computers.Interfaces
{
    /// <summary>
    /// An interface for a motherboard object
    /// </summary>
    public interface IMotherboard 
    { 
        /// <summary>
        /// This method should return a loaded value from the RAM
        /// </summary>
        /// <returns>Loaded value from the RAM</returns>
        int LoadRamValue(); 

        /// <summary>
        /// This method should save a value to the RAM
        /// </summary>
        /// <param name="value">A RAM value</param>
        void SaveRamValue(int value); 

        /// <summary>
        /// This method should draw on the video card
        /// </summary>
        /// <param name="data">The input string to draw</param>
        void DrawOnVideoCard(string data);
    }
}
