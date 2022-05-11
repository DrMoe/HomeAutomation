namespace DataHandler.Services
{
    public interface IBaseService
    {
        /// <summary>
        /// Add a new object to the database.
        /// </summary>
        /// <param name="value">Object to add.</param>
        void Add(object value);

        /// <summary>
        /// Save an object.
        /// </summary>
        /// <param name="value">Object to save.</param>
        /// <param name="id">1: Save/Update object. 0: Add object.</param>
        void Save(object value);

        /// <summary>
        /// Save multiple objects.
        /// </summary>
        /// <typeparam name="T">Type of object to save.</typeparam>
        /// <param name="values">Objects to save.</param>
        void Save<T>(List<T> values);

        /// <summary>
        /// Add multiple objects.
        /// </summary>
        /// <typeparam name="T">Type of object to add.</typeparam>
        /// <param name="values">Objects to add.</param>
        void Add<T>(List<T> values);

        /// <summary>
        /// Deletes an object.
        /// </summary>
        /// <param name="value">Object to delete.</param>
        void Delete(object value);

        /// <summary>
        /// Deletes multiple objects.
        /// </summary>
        /// <typeparam name="T">Type of object to delete.</typeparam>
        /// <param name="values">Objects to delete.</param>
        void Delete<T>(List<T> values);
    }
}