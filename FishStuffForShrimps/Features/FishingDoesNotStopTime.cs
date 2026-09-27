using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Menus;

namespace FishStuffForShrimps.Features;

public static class FishingDoesNotStopTime
{
    [EventPriority(EventPriority.High)]
    public static void OnUpdateTicked(object? sender, UpdateTickedEventArgs e)
    {
        if (
            !ModEntry.config.Enable_FishingDoesNotStopTime
            || !Context.IsWorldReady
            || Context.IsMultiplayer
            || Game1.activeClickableMenu is not BobberBar
            || Game1.currentMinigame != null
            || Game1.player.viewingLocation.Value != null
            || Game1.HostPaused
            || Game1.showingEndOfNightStuff
            || (!Game1.game1.IsActiveNoOverlay && Game1.options.pauseWhenOutOfFocus)
            || !Game1.shouldTimePass()
        )
            return;

        Game1.UpdateGameClock(Game1.currentGameTime);
    }
}
