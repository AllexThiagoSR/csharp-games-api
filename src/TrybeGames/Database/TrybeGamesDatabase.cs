namespace TrybeGames;

public class TrybeGamesDatabase
{
    public List<Game> Games = new List<Game>();

    public List<GameStudio> GameStudios = new List<GameStudio>();

    public List<Player> Players = new List<Player>();

    public void AddPlayer(string name)
    {
        Player player = new() { Name = name };
        player.Id = Players.Count + 1;
        this.Players.Add(player);
    }

    public void AddStudio(string name)
    {
        GameStudio gameStudio = new() { Name = name, CreatedAt = DateTime.Now };
        gameStudio.Id = this.GameStudios.Count + 1;
        this.GameStudios.Add(gameStudio);
    }

    public void AddGame(DateTime date, string name, GameType type)
    {
        Game game = new() { Name = name, GameType = type, ReleaseDate = date };
        game.Id = this.Games.Count + 1;
        this.Games.Add(game);
    }

    // 4. Crie a funcionalidade de buscar jogos desenvolvidos por um estúdio de jogos
    public List<Game> GetGamesDevelopedBy(GameStudio gameStudio)
    {
        return (
			from game in this.Games
			where game.DeveloperStudio == gameStudio.Id
			select game
		).ToList();
    }

    // 5. Crie a funcionalidade de buscar jogos jogados por uma pessoa jogadora
    public List<Game> GetGamesPlayedBy(Player player)
    {
        // Implementar
        return (
			from playerFound in this.Players
			where player.Id == playerFound.Id
			from game in this.Games
			where playerFound.GamesOwned.Contains(game.Id)
			select game
		).ToList();
    }

    // 6. Crie a funcionalidade de buscar jogos comprados por uma pessoa jogadora
    public List<Game> GetGamesOwnedBy(Player playerEntry)
    {
        // Implementar
        throw new NotImplementedException();
    }


    // 7. Crie a funcionalidade de buscar todos os jogos junto do nome do estúdio desenvolvedor
    public List<GameWithStudio> GetGamesWithStudio()
    {
        // Implementar
        throw new NotImplementedException();                      
    }
    
    // 8. Crie a funcionalidade de buscar todos os diferentes Tipos de jogos dentre os jogos cadastrados
    public List<GameType> GetGameTypes()
    {
        // Implementar
        throw new NotImplementedException();
    }

    // 9. Crie a funcionalidade de buscar todos os estúdios de jogos junto dos seus jogos desenvolvidos com suas pessoas jogadoras
    public List<StudioGamesPlayers> GetStudiosWithGamesAndPlayers()
    {
        // Implementar
        throw new NotImplementedException();
    }

}
