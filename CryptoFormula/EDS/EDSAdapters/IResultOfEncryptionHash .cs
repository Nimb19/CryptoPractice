namespace CryptoFormulaLibrary.EDS.EDSAdapters
{
    /// <summary>
    /// Каждый хеш-контроллер сам решит какой класс нужно будет подставить,
    /// и при его проверке преобразует общий интерфейс к производному классу.
    /// Все данные будут только у производных классов, и они будут у каждого свои.
    /// </summary>
    public interface IResultOfEncryptionHash
    {
    }
}
