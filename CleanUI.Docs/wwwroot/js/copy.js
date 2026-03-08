window.copy = async function (value) {
	try {
		await navigator.clipboard.writeText(value);
	} catch (error) {
		console.error('Error while trying to update the clipboard', error);

		alert('Something went wrong while trying to update your clipboard. Make sure you\'ve allowed clipboard updating in your browser settings.');
	}
}
