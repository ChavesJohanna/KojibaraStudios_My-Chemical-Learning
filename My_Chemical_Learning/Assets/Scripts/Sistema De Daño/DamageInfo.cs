public struct DamageInfo
{
    public float amount;
    public ElementType element;

    public DamageInfo(float amount, ElementType element)
    {
        this.amount = amount;
        this.element = element;
    }
}