public class RU : Localization
{
    public override string FillTheBoard()
    {
        return "Заполни поле фигурами";
    }

    public override string[] Greats()
    {
        return new string[] { "Шикарно!", "Отлично!", "Здорово!", "Просто космос!", "Ты крут!", "Фантастика!" };
    }

    public override string TapTileToRotate()
    {
        return "Нажми чтобы повернуть";
    }

    public override string UseHint()
    {
        return "Используй подсказку";
    }
}
