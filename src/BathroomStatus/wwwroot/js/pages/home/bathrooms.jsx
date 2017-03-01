var Bathrooms = React.createClass({
    getInitialState: function () {
        return { data: [] };
    },
    fetchDataFromServer: function () {
        var xhr = new XMLHttpRequest();
        var url = window.location.href + this.props.url;
        xhr.open('get', url, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        }.bind(this);
        xhr.send();
    },
    componentDidMount: function () {
        this.fetchDataFromServer();

        var bathroomsHub = $.connection.bathroomsHub;

        bathroomsHub.client.update = function (updatedBathroom) {
            var bathrooms = this.state.data;
            
            bathrooms.forEach(function (bathroom) {
                if (bathroom.Id !== updatedBathroom.Id) {
                    return;
                }

                bathroom.IsOpened = updatedBathroom.IsOpened;
            });

            this.setState({ data: bathrooms });
        }.bind(this);

        $.connection.hub.start();
    },
    render: function () {
        var bathrooms = this.state.data.map(function (bathroom) {
            return (
                <div key={bathroom.Id} className="row">
                    <div className="col s12 m9 l10">
                        <div className="section bathroom">
                            <h4>{bathroom.Name}</h4>
                            <span className={`waves-effect waves-light btn ${bathroom.IsOpened ? 'green' : 'red'}`}>{bathroom.IsOpened ? 'Opened' : 'Closed'}</span>
                        </div>
                    </div>
                </div>
          );
        });
        return (
          <div className="container">
            {bathrooms}
          </div>
        );
    }
});

ReactDOM.render(
  <Bathrooms url="/api/bathrooms" pollInterval="2000" />,
  document.getElementById('content')
);