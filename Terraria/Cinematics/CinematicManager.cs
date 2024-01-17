// Decompiled with JetBrains decompiler
// Type: Terraria.Cinematics.CinematicManager
// Assembly: Terraria, Version=1.4.1.2, Culture=neutral, PublicKeyToken=null
// MVID: 75D67D8C-B3D4-437A-95D3-398724A9BE22
// Assembly location: D:\Program Files\Steam\steamapps\content\app_105600\depot_105601\Terraria.exe

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Terraria.Cinematics
{
  public class CinematicManager
  {
    public static CinematicManager Instance = new CinematicManager();
    private List<Film> _films = new List<Film>();

    public void Update(GameTime gameTime)
    {
      if (this._films.Count <= 0)
        return;
      if (!this._films[0].IsActive)
        this._films[0].OnBegin();
      if (!Main.hasFocus || Main.gamePaused || this._films[0].OnUpdate(gameTime))
        return;
      this._films[0].OnEnd();
      this._films.RemoveAt(0);
    }

    public void PlayFilm(Film film) => this._films.Add(film);

    public void StopAll()
    {
    }
  }
}
