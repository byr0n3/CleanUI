let TOAST_TEMPLATE: HTMLTemplateElement | undefined;
let TOAST_CONTAINER: HTMLElement | undefined;

window.Toast = {
	active: new Map<string, ActiveToast>(),
	show({ id, type, title, body, duration }) {
		TOAST_TEMPLATE ??= document.getElementById('toast-template') as HTMLTemplateElement;
		TOAST_CONTAINER ??= document.getElementById('toast-container');

		type ??= 'info';

		const toastNode = document.importNode(TOAST_TEMPLATE, true);
		const toast = toastNode.content.firstElementChild;
		const header = toast.querySelector('.toast-header');
		const content = toast.querySelector('.toast-content');

		toast.id = id;

		header.querySelector(`[data-icon='${type}']`)?.removeAttribute('hidden');
		header.querySelector('.toast-title')?.append(document.createTextNode(title));
		content.append(document.createTextNode(body));

		header.querySelector('button')?.addEventListener('click', () => window.Toast.remove(id));

		TOAST_CONTAINER.append(toast);

		const timeout = duration > 0 ? window.setTimeout(() => window.Toast.remove(id), duration) : -1;

		window.Toast.active.set(toast.id, { toast, timeout });
	},
	remove(id) {
		const toast = window.Toast.active.get(id);

		if (!toast) {
			return;
		}

		window.Toast.active.delete(id);

		if (toast.timeout != -1) {
			window.clearTimeout(toast.timeout);
		}

		toast.toast.addEventListener('transitionend', () => toast.toast.remove());
		toast.toast.classList.add('exit');
	}
}
