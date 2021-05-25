import React, { Component } from 'react';
import './Hotels.css';

export class Hotels extends Component {
    static displayName = Hotels.name;

    constructor(props) {
        super(props);
        this.state = { hotels: [], loading: true };
    }

    componentDidMount() {
        this.populateWeatherData();
    }

    static renderHotels(hotels) {
        return (
            <div className='hotelsContainer'>
                {hotels.map(hotel =>
                    <div className='card'
                        key={hotel.id}>
                        <div className='card-body'>
                            <h5 className='card-title'>{hotel.name}</h5>
                            <p className='card-text'>{hotel.description}</p>
                            <p className='card-text'>{hotel.address}</p>
                        </div>
                        <div className='buttonContainer'>
                            <p className='btn btn-primary'>{hotel.rate}</p>
                        </div>
                    </div>
                )}
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Hotels.renderHotels(this.state.hotels);

        return (
            <div className="commonContainer">
                <h1 id="tabelLabel" >Hotels</h1>
                {contents}
                <h6>The best hotels for your attention</h6>
            </div>
        );
    }

    async populateWeatherData() {
        const response = await fetch('api/hotels/gethotels');
        const data = await response.json();
        this.setState({ hotels: data.body, loading: false });
    }
}
