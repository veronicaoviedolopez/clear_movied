import React from "react";

export default function DetailMovie(props) {
    const displayMovies = (props) => {
        const {movies} = props;
        if(movies.length > 0) {
            return(
                movies.map((m, index) => {
                    return(
                        <div className="card p-2 m-2" key={index}>
                            <img className="imgSizePosterMovie"  src={m.poster} alt="Card cap"></img>
                              <h6>{m.title}</h6>
                            <p className="card-text" >{m.summary}</p>
                             </div>
                    )
                })
        )
        }else {
                return(<div>NO DATA</div>)
        }
    }
    return(
        <div className="d-flex flex-row">
        {displayMovies(props)}
        </div>
    )
}
