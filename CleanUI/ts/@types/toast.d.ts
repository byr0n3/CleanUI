export {};

declare global {
	type ToastType = 'info' | 'success' | 'warning' | 'danger';

	type ToastConfig = {
		readonly id: string;
		readonly type?: ToastType | undefined;
		readonly title?: string | undefined;
		readonly body?: string | undefined;
		readonly duration: number;
	};

	type ActiveToast = {
		readonly toast: Element;
		readonly timeout: number;
	}
}
