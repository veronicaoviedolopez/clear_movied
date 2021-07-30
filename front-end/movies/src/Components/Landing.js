import React, { useEffect, useState } from "react";
import axios from "axios";
import DetailMovie from "./Movie";

const baseURL = "https://localhost:5001/api";

export default function Landing() {
  const [movies, setMovies] = useState("");
  let [genre, setGenre] = useState("0");
  let [title, setTitle] = useState("");
  let [actor, setActor] = useState("0");
  let [actorsList, setActorsList] = useState([]);
  let [genresList, setGenresList] = useState([]);

  //get data from API
  const getAllMovies = (_baseURL) => {
    axios
      .get(_baseURL)
      .then((res) => {
        setMovies(res.data);
      })
      .catch((e) => console.log(e));
  };
  const getAllActors = (_actorsURL) => {
    axios
      .get(_actorsURL)
      .then((res) => {
        setActorsList(res.data);
      })
      .catch((e) => console.log(e));
  };
  const getAllGenres = (_genresURL) => {
    axios
      .get(_genresURL)
      .then((res) => {
        setGenresList(res.data);
      })
      .catch((e) => console.log(e));
  };

  useEffect(() => {
    getAllActors(`${baseURL}/actors`);
  }, []);
  useEffect(() => {
    getAllGenres(`${baseURL}/genres`);
  }, []);
  useEffect(() =>{
    search();
  }, [genre, title, actor]);

  const search = () => {
    console.log("genre", genre);
    let filterQry = "";
    if (genre !== "0") {
      filterQry += `&GenreId=${genre}`;
    }
    if (actor !== "0") {
      filterQry += `&ActorId=${actor}`;
    }
    if (title !== "") {
      filterQry += `&Title=${title}`;
    }
    getAllMovies(`${baseURL}/movies/filter?${filterQry}`);
    console.log("filterQry", filterQry);
  };

  return (
    <div className="mx-2">
      <h6>Filters</h6>
      <div className="d-flex flex-row justify-content-start">
        <div className="form-group px-2">
          <label htmlFor="genre">Genres</label>
          <select
            onChange={(e) => {
              setGenre(e.target.value);
            }}
            id="genre"
            className="form-control">
            <option value="0"> -- Select a genre -- </option>
            {genresList.map((g, index) => (
              <option key={index} value={g.id}>
                {g.id}-{g.name}
              </option>
            ))}
          </select>
        </div>

        <div className="form-group px-2">
          <label htmlFor="title">Title</label>
          <input
            type="text"
            className="form-control"
            id="title"
            placeholder="Enter Title"
            onChange={(e) => {
              setTitle(e.target.value);
              if (e.target.value.length > 3 || e.target.value.length === 0) {
                search();
              }
            }}
          />
        </div>

        <div className="form-group px-2">
          <label htmlFor="actor">Actor</label>
          <select
            onChange={(e) => setActor(e.target.value)}
            id="actor"
            className="form-control"
          >
            <option value="0"> -- Select an actor -- </option>
            {actorsList.map((g, index) => (
              <option key={index} value={g.id}>
                {g.name}
              </option>
            ))}
          </select>
        </div>

        <div className="form-group px-2">
          <br></br>
          <button
            type="button"
            className="btn btn-outline-primary h-1"
            onClick={search}
          >
            search
          </button>
        </div>
      </div>

      <DetailMovie movies={movies} />
    </div>
  );
}
