{
    class Movie
    {
        public String Title { get; private set; }
        public String Description { get; private set; }
        public String Rating { get; private set; }
        public String Length { get; private set; }

        public Movie(String title, String description, String rating, String length)
        {
            this.Title = title;
            this.Description = description;
            this.Rating = rating;
            this.Length = length;
        }

    }
}

using System.IO;

namespace WindowsFormsApplication1
{
    class MovieList
    {
        private List<Movie> movies = new List<Movie>();

        public MovieList(String fileName)
        {
            Load(fileName);
        }

        private void Load(String fileName)
        {
            StreamReader fileIn = new StreamReader(fileName);

            while (!fileIn.EndOfStream)
            {
                //String title = fileIn.ReadLine().Trim();
                String[] description = fileIn.ReadLine().Split(':'); //null error
               // String[] rating = fileIn.ReadLine().Split(':');
               // String[] length = fileIn.ReadLine().Split(':');

                Movie tempMovie = new Movie(description[0], description[1], description[2], description[3]);
                movies.Add(tempMovie);
            }

            fileIn.Close();
        }

        public List<String> GetMovieNames()
        {
            List<String> names = new List<String>();

            foreach (Movie item in movies)
            {
                names.Add(item.Title);
            }

            return names;
        }

        public Movie GetMovie(String title)
        {
            foreach (Movie item in movies)
            {
                if (item.Title.ToLower().Trim() == title.ToLower().Trim())
                {
                    return item;
                }
            }

            return null;
        }
    }
}


namespace WindowsFormsApplication1
{
    public partial class FormMovie : Form
    {
        MovieList myMovies = new MovieList("movies.txt");
        
        public FormMovie()
        {
            InitializeComponent();
        }

        private void FormMovie_Load(object sender, EventArgs e)
        {
            List<String> names = myMovies.GetMovieNames();

            //loop through names and add them to combo box
            foreach (String title in names)
            {
                cmbMovieName.Items.Add(title);
            }
        }

        private void cmbMovieName_SelectedIndexChanged(object sender, EventArgs e)
        {
            String title = cmbMovieName.SelectedItem.ToString();
            Movie myMovie = myMovies.GetMovie(title);

            rtxtDescription.Text= myMovie.Description;
            rtxtMovieTitle.Text = myMovie.Title;
            rtxtRating.Text = myMovie.Rating;
            rtxtLength.Text = myMovie.Length;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}

