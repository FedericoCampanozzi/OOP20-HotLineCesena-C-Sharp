namespace Zammarchi.Items
{
    /// <summary>
    ///     A basic game entity, characterized by an usage.
    /// </summary>
    public interface IItems
    {
        /// <summary>
        ///     The action performed when an item is picked up.
        /// </summary>
        void Usage();
    }
}
