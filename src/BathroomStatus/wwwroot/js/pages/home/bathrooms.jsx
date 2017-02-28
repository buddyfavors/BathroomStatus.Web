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
        window.setInterval(this.fetchDataFromServer, this.props.pollInterval);
    },
    render: function () {
        var bathrooms = this.state.data.map(function (bathroom) {
            return (
            <div key={bathroom.id} className="bathroom">
                {bathroom.name}: <span className={bathroom.isOpened ? 'opened' : 'closed'}>{bathroom.isOpened ? 'Opened' : 'Closed'}</span>
            </div>
          );
        });
        return (
          <div>
            {bathrooms}
          </div>
        );
    }
});

ReactDOM.render(
  <Bathrooms url="/api/bathrooms" pollInterval="2000" />,
  document.getElementById('content')
);