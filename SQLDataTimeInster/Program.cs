using SQLDataTimeInster;
using Newtonsoft.Json;

internal class Program
{
	public static async Task DeleteOldSensorsDataAsync()
	{
		var context = new Bdsem3Context();
		while (true)
		{
			await Task.Delay(TimeSpan.FromMinutes(100));
			DateTime currentTime = DateTime.UtcNow;
			var dataToDelete = context.SensorsData
				.Where(s => s.DateTime < currentTime)
				.ToList();

			if (dataToDelete.Any())
			{
				context.SensorsData.RemoveRange(dataToDelete);
				await context.SaveChangesAsync();
				Console.WriteLine($"Deleted {dataToDelete.Count}");
			}
		}
	}
	private static async Task Main(string[] args)
	{
		using (var context = new Bdsem3Context())
		{
			int n = 1;
			Random rand = new Random();
			var deleteTask = DeleteOldSensorsDataAsync();
			List<SensorsDatum> sensorsDatums = new List<SensorsDatum>();

			for (int i = 1; i < 1000000; i++)
			{
				for (int j = 1; j < 101; j++)
				{
					var sensorsDatum = new SensorsDatum
					{
						//Id = n++,
						RoomId = rand.Next(12, 311),
						Temperature = rand.NextDouble() * 40 - 1,
						Pressure = rand.Next(760, 1013),
						Humidity = rand.Next(30, 50),
						DateTime = DateTime.UtcNow
					};
					sensorsDatums.Add(sensorsDatum);
					Console.WriteLine($"{n++}: {JsonConvert.SerializeObject(sensorsDatum)}");
				}
				context.ChangeTracker.AutoDetectChangesEnabled = false;
				context.SensorsData.AddRange(sensorsDatums);
				context.ChangeTracker.DetectChanges();
				context.SaveChanges();
				context.ChangeTracker.AutoDetectChangesEnabled = true;

				await Task.Delay(0);

				sensorsDatums.Clear();
			}
			await deleteTask;
		}

		//Mongo DB 5237 and 442 за 1 сек
		//SQL 1450 and 770 за 1 сек
	}
}