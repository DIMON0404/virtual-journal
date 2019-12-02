namespace Journal_Model.Core
{
    public interface IObjectRemover<T>
    {
        void OnRemoveObject(T objectForRemove);
    }
}