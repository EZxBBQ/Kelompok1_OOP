using System;

public class EnemyManager : ISubject
{
    private List<IObserver> observers = new List<IObserver>();

    public void Attach(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify(Enemy enemy)
    {
        foreach (var observer in observers)
        {
            observer.Update(enemy);
        }
    }

    public void EnemyDefeated(Enemy enemy)
    {
        Notify(enemy);
    }
}