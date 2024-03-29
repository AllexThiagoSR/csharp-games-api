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
			from game in this.Games
			where game.Players.Contains(player.Id)
			select game
		).ToList();
    }

    // 6. Crie a funcionalidade de buscar jogos comprados por uma pessoa jogadora
    public List<Game> GetGamesOwnedBy(Player playerEntry)
    {
        // Implementar
        return (
			from player in this.Players
			where playerEntry.Id == player.Id
			from game in this.Games
			where player.GamesOwned.Contains(game.Id)
			select game
		).ToList();
    }


    // 7. Crie a funcionalidade de buscar todos os jogos junto do nome do estúdio desenvolvedor
    public List<GameWithStudio> GetGamesWithStudio()
    {
        // Implementar
        return (
			from game in this.Games
			join studio in this.GameStudios
			on game.DeveloperStudio equals studio.Id
			select new GameWithStudio {
				GameName = game.Name,
				StudioName = studio.Name,
				NumberOfPlayers = game.Players.Count,
			}
		).ToList();                   
    }
    
    // 8. Crie a funcionalidade de buscar todos os diferentes Tipos de jogos dentre os jogos cadastrados
    public List<GameType> GetGameTypes()
    {
        // Implementar
        return (
			from game in this.Games
			select game.GameType
		).Distinct().ToList();
    }

    // 9. Crie a funcionalidade de buscar todos os estúdios de jogos junto dos seus jogos desenvolvidos com suas pessoas jogadoras
    public List<StudioGamesPlayers> GetStudiosWithGamesAndPlayers()
    {
        // Implementar
        return (
			from studio in this.GameStudios
			select new StudioGamesPlayers {
				GameStudioName = studio.Name,
				Games = (
					from game in this.Games
					where game.DeveloperStudio == studio.Id
					select new GamePlayer {
						GameName = game.Name,
						Players = (
							from player in this.Players
							where game.Players.Contains(player.Id)
							select player
						).ToList()
					}
				).ToList()
			}
		).ToList();
    }

}
